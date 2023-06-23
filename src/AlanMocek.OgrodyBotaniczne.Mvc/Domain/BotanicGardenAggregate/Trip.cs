namespace AlanMocek.OgrodyBotaniczne.Mvc.Domain.BotanicGardenAggregate
{
    public class Trip
    {
        public int Number { get; set; }

        public int NumberOfPeople { get; set; }

        public DateOnly Date { get; set; }

        public string? Comment { get; set; }

        public List<TripZone> Zones { get; set; }

        private Trip()
        {
        }

        internal Trip(int number, int numberOfPeople, DateOnly date, string? comment, IEnumerable<TripZone> zones)
        {
            if(!zones.Any())
            {
                throw new Exception("At least one zone must be added.");
            }

            if(zones.DistinctBy(zone => zone.ZoneNumber).Count() != zones.Count())
            {
                throw new Exception("Zone can be assignes only one time.");
            }

            this.Number = number;
            this.NumberOfPeople = numberOfPeople;
            this.Date = date;
            this.Comment = comment;
            this.Zones = new List<TripZone>(zones);
        }
    }
}
