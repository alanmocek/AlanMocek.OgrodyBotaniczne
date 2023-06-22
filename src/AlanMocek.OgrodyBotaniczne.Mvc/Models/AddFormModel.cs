namespace AlanMocek.OgrodyBotaniczne.Mvc.Models
{
    public class AddFormModel
    {
        public int NumberOfPeople { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public AddFormItem[] Items { get; set; }
    }

    public class AddFormItem
    {
        public int ZoneNumber { get; set; }

        public string Comment { get; set; }
    }
}
