namespace COVID_19_Tracker.Models
{
    public class CovidDataModel
    {
        public string Country { get; set; }
        public int TotalConfirmed { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalRecovered { get; set; }
        public int Active { get; set; }
        public int NewDeaths { get; set; }
        public int NewConfirmed { get; set; }
        public int NewRecovered { get; set; }
        public DateTime TodaysDate { get; set; } = DateTime.Now;
    }

}
