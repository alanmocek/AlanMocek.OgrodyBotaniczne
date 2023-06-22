using MediatR;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Commands.DeleteTripCommand
{
    public class DeleteTrip : IRequest
    {
        public required int TripNumber { get; init; }
    }
}
