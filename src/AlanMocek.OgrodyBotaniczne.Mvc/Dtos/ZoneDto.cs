namespace AlanMocek.OgrodyBotaniczne.Mvc.Dtos
{
    public class ZoneDto
    {
        public required int Number { get; init; }

        public required string Label { get; init; }

        public required int Discount { get; init; }

        public required int PricePerPerson { get; init; }
    }
}
