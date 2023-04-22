namespace COVID_19_Tracker.Models
{
    public class ApiResult
    {
        public List<CountryData> Countries { get; set; }
    }

    public class CountryData
    {
        public string Country { get; set; }
        public int TotalConfirmed { get; set; }
        public int TotalDeaths { get; set; }
        public int TotalRecovered { get; set; }
        public int NewDeaths { get; set; }
        public int NewConfirmed { get; set; }
        public int NewRecovered { get; set; }




    }
}
