using AlanMocek.OgrodyBotaniczne.Mvc.Commands.CreateTripCommand;
using AlanMocek.OgrodyBotaniczne.Mvc.Commands.DeleteTripCommand;
using AlanMocek.OgrodyBotaniczne.Mvc.Models;
using AlanMocek.OgrodyBotaniczne.Mvc.Queries.GetTripQuery;
using AlanMocek.OgrodyBotaniczne.Mvc.Queries.GetTripsQuery;
using AlanMocek.OgrodyBotaniczne.Mvc.Queries.GetZones;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Mvc.Controllers
{
    public class MainController : Controller
    {
        private readonly IMediator mediator;

        public MainController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("", Name = "getList")]
        public async Task<IActionResult> GetListAsync(CancellationToken cancellationToken)
        {
            var getTripsQuery = new GetTrips();
            var getTripsQueryResult = await mediator.Send(getTripsQuery, cancellationToken);

            var getZonesQuery = new GetZones();
            var getZonesQueryResult = await mediator.Send(getZonesQuery, cancellationToken);

            var viewModel = new ListViewModel()
            {
                Trips = getTripsQueryResult.Select(dto => new TripModel()
                {
                    Number = dto.Number,
                    Date = dto.Date,
                    NumberOfPeople = dto.NumberOfPeople,
                    Comment = dto.Comment ?? string.Empty,
                    Zones = dto.Zones.Select(tripZone => new TripZoneModel()
                    {
                        Label = getZonesQueryResult.First(zone => zone.Number == tripZone.ZoneNumber).Label,
                        Comment = tripZone.Comment,
                    }).ToArray(),
                }).ToArray()
            };

            return View("ListView", viewModel);
        }

        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> GetAdd(CancellationToken cancellationToken)
        {
            var getZonesQuery = new GetZones();
            var getZonesResult = await mediator.Send(getZonesQuery, cancellationToken);

            var viewModel = new AddViewModel()
            {
                Form = new AddFormModel(),
                Zones = getZonesResult.Select(zoneDto => new ZoneModel()
                {
                    Number = zoneDto.Number,
                    Label = zoneDto.Label,
                }).ToArray()
            };

            return View("AddView", viewModel);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> PostAddAsync([FromForm] AddFormModel model)
        {
            var registerTripCommand = new RegisterTrip()
            {
                Trip = new RegisterTrip.TripDetails()
                {
                    Comment = model.Comment,
                    NumberOfPeople = model.NumberOfPeople,
                    Date = new DateOnly(model.Date.Year, model.Date.Month, model.Date.Day),
                },
                Zones = model.Items.Select(item => new RegisterTrip.ZoneDetails()
                {
                    Comment = item.Comment,
                    Number = item.ZoneNumber
                }).ToArray(),
            };

            await this.mediator.Send(registerTripCommand); 

            return RedirectToRoute("getList");
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> PostDeleteAsync([FromForm] DeleteTripModel model, CancellationToken cancellationToken)
        {
            var deleteTripCommand = new DeleteTrip
            {
                TripNumber = model.TripNumber,
            };
            await this.mediator.Send(deleteTripCommand, cancellationToken);

            return RedirectToRoute("getList");
        }

        [HttpGet]
        [Route("preview/{number}")]
        public async Task<IActionResult> GetPreviewAsync(int number, CancellationToken cancellationToken)
        {
            var getTripQuery = new GetTrip()
            {
                TripNumber = number
            };
            var getTripQueryResult = await this.mediator.Send(getTripQuery, cancellationToken);

            var getZonesQuery = new GetZones();
            var getZonesQueryResult = await mediator.Send(getZonesQuery, cancellationToken);

            var viewModel = new PreviewViewModel()
            {
                TripModel = new TripModel()
                {
                    Number = getTripQueryResult.Number,
                    Date = getTripQueryResult.Date,
                    NumberOfPeople = getTripQueryResult.NumberOfPeople,
                    Comment = getTripQueryResult.Comment ?? string.Empty,
                    Zones = getTripQueryResult.Zones.Select(tripZone => new TripZoneModel()
                    {
                        Label = getZonesQueryResult.First(zone => zone.Number == tripZone.ZoneNumber).Label,
                        Comment = tripZone.Comment,
                    }).ToArray(),
                }
            };

            return View("PreviewView", viewModel);
        }
    }
}
