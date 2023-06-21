namespace AlanMocek.OgrodyBotaniczne.Domain.BotanicGardenAggregate
{
    public class TripZone
    {
        public Guid ZoneId { get; set; }

        public string? Comment { get; set; }

        public TripZone(Zone zone, string? comment)
        {
            this.ZoneId = zone.Id;
            this.Comment = comment;
        }
    }
}
