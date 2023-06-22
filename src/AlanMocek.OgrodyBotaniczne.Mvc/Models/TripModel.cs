namespace AlanMocek.OgrodyBotaniczne.Mvc.Models
{
    public class TripModel
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public int NumberOfPeople { get; set; }

        public string? Comment { get; set; }

        public TripZoneModel[] Zones { get; set; }
    }
}
