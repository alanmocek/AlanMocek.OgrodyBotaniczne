namespace AlanMocek.OgrodyBotaniczne.Mvc.Domain.BotanicGardenAggregate
{
    public class TripZone
    {
        public int ZoneNumber { get; set; }

        public string? Comment { get; set; }

        private TripZone()
        {
        }

        public TripZone(Zone zone, string? comment)
        {
            this.ZoneNumber = zone.Number;
            this.Comment = comment;
        }
    }
}
