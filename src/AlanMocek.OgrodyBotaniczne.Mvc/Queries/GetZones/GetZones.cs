using AlanMocek.OgrodyBotaniczne.Mvc.Dtos;
using MediatR;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Queries.GetZones
{
    public class GetZones : IRequest<IEnumerable<ZoneDto>>
    {
    }
}
