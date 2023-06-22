using MediatR;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Commands.CreateTripCommand
{
    public class RegisterTrip : IRequest
    {
        public required TripDetails Trip { get;  init; }

        public required ZoneDetails[] Zones { get;  init; }

        public class TripDetails
        {
            public required int NumberOfPeople { get; init; }

            public required DateOnly Date { get; init; }

            public required string? Comment { get; init; }
        }

        public class ZoneDetails
        {
            public required int Number { get; init; }

            public required string? Comment { get; init; }
        }
    }
}
