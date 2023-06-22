using AlanMocek.OgrodyBotaniczne.Mvc.Db;
using AlanMocek.OgrodyBotaniczne.Mvc.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Queries.GetTripsQuery
{
    public class GetTripsHandler : IRequestHandler<GetTrips, IEnumerable<TripDto>>
    {
        private readonly OgrodyBotaniczneContext context;

        public GetTripsHandler(OgrodyBotaniczneContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TripDto>> Handle(GetTrips request, CancellationToken cancellationToken)
        {
            var botanicGarden = await this.context.BotanicGardens.FirstAsync();

            var tripDtos = new List<TripDto>();

            foreach(var trip in botanicGarden.Trips)
            {
                var tripDto = new TripDto()
                {
                    Number = trip.Number,
                    Date = trip.Date.ToDateTime(TimeOnly.MinValue),
                    NumberOfPeople = trip.NumberOfPeople,
                    Comment = trip.Comment,
                    Zones = trip.Zones.Select(tripZone =>
                    new TripZoneDto()
                    {
                        ZoneNumber = tripZone.ZoneNumber,
                        Comment = tripZone.Comment,
                    }).ToArray(),
            };

                tripDtos.Add(tripDto);
            }

            return tripDtos;
        }
    }
}
