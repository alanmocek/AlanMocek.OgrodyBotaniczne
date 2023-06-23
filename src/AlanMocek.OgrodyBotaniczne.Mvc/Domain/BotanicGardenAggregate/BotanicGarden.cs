namespace AlanMocek.OgrodyBotaniczne.Mvc.Domain.BotanicGardenAggregate
{
    public class BotanicGarden
    {
        private readonly List<Trip> trips;

        private readonly List<Zone> zones;

        public Guid Id { get; private set; }

        public IEnumerable<Trip> Trips => trips.AsReadOnly();

        public IEnumerable<Zone> Zones => zones.AsReadOnly();

        public int NextTripNumber { get; private set; }

        public int NextZoneNumber { get; private set; }

        public int AllowedTripsPerDay { get; private set; }

        public int MinimumNumberOfPeople { get; private set; }

        public BotanicGarden(int allowedTripsPerDay, int minimumNumberOfPeople)
        {
            this.Id = Guid.NewGuid();
            this.zones = new List<Zone>();
            this.trips = new List<Trip>();
            this.AllowedTripsPerDay = allowedTripsPerDay;
            this.MinimumNumberOfPeople = minimumNumberOfPeople;
            this.NextTripNumber = 1;
            this.NextZoneNumber = 1;
        }

        public void RegisterTrip(int numberOfPeople, DateOnly date, string? comment, IEnumerable<TripZone> tripZones)
        {
            if(numberOfPeople < this.MinimumNumberOfPeople)
            {
                throw new Exception($"Number of people must be at least {MinimumNumberOfPeople}");
            }

            if(Trips.Where(trip => trip.Date == date).Count() >= AllowedTripsPerDay + 1) 
            {
                throw new Exception("Only 2 trips per day are allowed");
            }

            var trip = new Trip(this.NextTripNumber++ , numberOfPeople, date, comment, tripZones);

            this.trips.Add(trip);
        }

        public void AddZone(string label, int pricePerPerson, int discount)
        {
            var zone = new Zone(this.NextZoneNumber++ ,label, pricePerPerson, discount);

            this.zones.Add(zone);
        }

        public void DeleteTrip(Trip trip, ITimeProvider timeProvider)
        {
            var nowDate = timeProvider.Now.Date;

            var tripDate = trip.Date.ToDateTime(TimeOnly.MinValue).Date;

            if(tripDate <= nowDate)
            {
                throw new Exception("Cannot delete trip");
            }

            this.trips.Remove(trip);
        }
    }
}
