namespace AlanMocek.OgrodyBotaniczne.Domain.BotanicGardenAggregate
{
    public class BotanicGarden
    {
        public Guid Id { get; set; }

        public List<Trip> Trips { get; set; }

        public List<Zone> Zones { get; set; }

        public int AllowedTripsPerDay { get; set; }

        public void RegisterTrip(int numberOfPeople, DateOnly date, string? comment, IEnumerable<TripZone> tripZones)
        {
            if(Trips.Where(trip => trip.Date == date).Count() >= AllowedTripsPerDay + 1) 
            {
                throw new Exception("Only 2 trips per day are allowed");
            }

            var trip = new Trip(numberOfPeople, date, comment, tripZones);

            Trips.Add(trip);
        }
    }
}
