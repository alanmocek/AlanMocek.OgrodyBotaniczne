namespace AlanMocek.OgrodyBotaniczne.Models
{
    public class MainModel
    {
        public List<TripApplicationModel> TripApplications { get; set; }
    }

    public class TripApplicationModel
    {
        TripHeaderModel Header { get; set; }
    }

    public class TripHeaderModel
    {

    }

}
