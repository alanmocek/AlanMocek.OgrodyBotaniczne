namespace AlanMocek.OgrodyBotaniczne.Domain.BotanicGardenAggregate
{
    public class Trip
    {
        public Guid Id { get; set; }

        public int NumberOfPeople { get; set; }

        public DateOnly Date { get; set; }

        public string? Comment { get; set; }

        public List<TripZone> Zones { get; set; }

        public Trip(int numberOfPeople, DateOnly date, string? comment, IEnumerable<TripZone> zones)
        {
            if(this.NumberOfPeople < 5) // change to constant
            {
                throw new Exception("Number of people must be at least 5.");
            }

            if(zones.DistinctBy(zone => zone.ZoneId).Count() != zones.Count())
            {
                throw new Exception("Zone can be assignes only one time.");
            }

            this.Id = Guid.NewGuid();
            this.NumberOfPeople = numberOfPeople;
            this.Date = date;
            this.Comment = comment;
            this.Zones = new List<TripZone>(zones);
        }
    }
}
