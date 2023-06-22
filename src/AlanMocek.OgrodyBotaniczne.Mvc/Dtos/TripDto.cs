namespace AlanMocek.OgrodyBotaniczne.Mvc.Dtos
{
    public class TripDto
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public int NumberOfPeople { get; set; }

        public string? Comment { get; set; }

        public TripZoneDto[] Zones { get; set; }
    }
}
