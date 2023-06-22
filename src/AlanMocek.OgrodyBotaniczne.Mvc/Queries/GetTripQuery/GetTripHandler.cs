using AlanMocek.OgrodyBotaniczne.Mvc.Db;
using AlanMocek.OgrodyBotaniczne.Mvc.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Queries.GetTripQuery
{
    public class GetTripHandler : IRequestHandler<GetTrip, TripDto>
    {
        private readonly OgrodyBotaniczneContext context;

        public GetTripHandler(OgrodyBotaniczneContext context)
        {
            this.context = context;
        }

        public async Task<TripDto> Handle(GetTrip request, CancellationToken cancellationToken)
        {
            var botanicGarden = await this.context.BotanicGardens.FirstAsync(cancellationToken);

            var trip = botanicGarden.Trips.First(trip => trip.Number == request.TripNumber);

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

            return tripDto;
        }
    }
}
