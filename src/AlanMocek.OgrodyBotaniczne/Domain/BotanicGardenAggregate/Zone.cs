namespace AlanMocek.OgrodyBotaniczne.Domain.BotanicGardenAggregate
{
    public class Zone
    {
        public Guid Id { get; set; }

        public string Label { get; set; }

        public int PricePerPerson { get; set; }

        public int Discount { get; set; }

        public Zone(string label, int pricePerPerson, int discount)
        {
            this.Id = Guid.NewGuid();
            this.Label = label;
            this.PricePerPerson = pricePerPerson;
            this.Discount = discount;
        }
    }
}
