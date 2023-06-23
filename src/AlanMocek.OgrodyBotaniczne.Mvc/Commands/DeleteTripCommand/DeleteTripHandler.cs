using AlanMocek.OgrodyBotaniczne.Mvc.Db;
using AlanMocek.OgrodyBotaniczne.Mvc.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Commands.DeleteTripCommand
{
    public class DeleteTripHandler : IRequestHandler<DeleteTrip>
    {
        private readonly OgrodyBotaniczneContext context;
        private readonly ITimeProvider timeProvider;

        public DeleteTripHandler(
            OgrodyBotaniczneContext context,
            ITimeProvider timeProvider)
        {
            this.context = context;
            this.timeProvider = timeProvider;
        }

        public async Task Handle(DeleteTrip request, CancellationToken cancellationToken)
        {
            var botanicGarden = await this.context.BotanicGardens.FirstAsync();

            var trip = botanicGarden.Trips.FirstOrDefault(trip => trip.Number == request.TripNumber);

            if (trip == null)
            {
                throw new Exception("Trip not found.");
            }

            botanicGarden.DeleteTrip(trip, timeProvider);

            await this.context.SaveChangesAsync();
        }
    }
}
