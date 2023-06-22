using AlanMocek.OgrodyBotaniczne.Mvc.Db;
using AlanMocek.OgrodyBotaniczne.Mvc.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Queries.GetZones
{
    public class GetZonesHandler : IRequestHandler<GetZones, IEnumerable<ZoneDto>>
    {
        private readonly OgrodyBotaniczneContext context;

        public GetZonesHandler(OgrodyBotaniczneContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ZoneDto>> Handle(GetZones request, CancellationToken cancellationToken)
        {
            var botanicGarden = await context.BotanicGardens.FirstAsync(cancellationToken);

            var zones = botanicGarden.Zones;

            var zoneDtos = zones.Select(zone => new ZoneDto()
            {
                Number = zone.Number,
                Label = zone.Label,
                Discount = zone.Discount,
                PricePerPerson = zone.PricePerPerson
            });

            return zoneDtos;
        }
    }
}
