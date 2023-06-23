namespace AlanMocek.OgrodyBotaniczne.Mvc.Domain
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime Now => DateTime.Now;
    }
}
