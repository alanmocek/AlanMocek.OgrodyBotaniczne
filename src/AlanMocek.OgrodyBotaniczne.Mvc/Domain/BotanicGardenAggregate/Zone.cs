namespace AlanMocek.OgrodyBotaniczne.Mvc.Domain.BotanicGardenAggregate
{
    public class Zone
    {
        public int Number { get; set; }

        public string Label { get; set; }

        public int PricePerPerson { get; set; }

        public int Discount { get; set; }

        private Zone()
        {
        }

        internal Zone(int number, string label, int pricePerPerson, int discount)
        {
            this.Number = number;
            this.Label = label;
            this.PricePerPerson = pricePerPerson;
            this.Discount = discount;
        }
    }
}
