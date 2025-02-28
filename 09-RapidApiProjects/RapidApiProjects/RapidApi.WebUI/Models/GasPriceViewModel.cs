namespace RapidApi.WebUI.Models
{
    public class GasPriceViewModel
    {
        public List<Result> Results { get; set; }
        public bool success { get; set; }

        public class Result
        {
            public string currency { get; set; }
            public string lpg { get; set; }
            public string diesel { get; set; }
            public string gasoline { get; set; }
            public string country { get; set; }
        }
    }
}
