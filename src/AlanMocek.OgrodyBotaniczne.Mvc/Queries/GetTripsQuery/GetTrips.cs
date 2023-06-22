using AlanMocek.OgrodyBotaniczne.Mvc.Dtos;
using MediatR;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Queries.GetTripsQuery
{
    public class GetTrips : IRequest<IEnumerable<TripDto>>
    {
    }
}
