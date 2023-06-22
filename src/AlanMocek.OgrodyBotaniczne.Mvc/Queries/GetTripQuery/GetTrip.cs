using AlanMocek.OgrodyBotaniczne.Mvc.Dtos;
using MediatR;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Queries.GetTripQuery
{
    public class GetTrip : IRequest<TripDto>
    {
        public required int TripNumber { get; init; }
    }
}
