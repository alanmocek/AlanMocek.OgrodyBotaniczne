using AlanMocek.OgrodyBotaniczne.Mvc.Db;
using AlanMocek.OgrodyBotaniczne.Mvc.Domain.BotanicGardenAggregate;
using MediatR;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Commands.CreateTripCommand
{
    public class RegisterTripHandler : IRequestHandler<RegisterTrip>
    {
        private readonly OgrodyBotaniczneContext context;

        public RegisterTripHandler(OgrodyBotaniczneContext context)
        {
            this.context = context;
        }

        public async Task Handle(RegisterTrip request, CancellationToken cancellationToken)
        {
            var botanicGarden = context.BotanicGardens.First();

            var zonesIds = request.Zones.Select(x => x.Number);
            var zones = botanicGarden.Zones.Where(zone => zonesIds.Contains(zone.Number));

            var tripZones = new List<TripZone>();

            foreach(var zoneDetails in request.Zones)
            {
                var zone = botanicGarden.Zones.First(zone => zone.Number ==  zoneDetails.Number);
                var tripZone = new TripZone(zone, zoneDetails.Comment);

                tripZones.Add(tripZone);
            }

            botanicGarden.RegisterTrip(
                request.Trip.NumberOfPeople,
                request.Trip.Date,
                request.Trip.Comment,
                tripZones);

            await this.context.SaveChangesAsync();
        }
    }
}
