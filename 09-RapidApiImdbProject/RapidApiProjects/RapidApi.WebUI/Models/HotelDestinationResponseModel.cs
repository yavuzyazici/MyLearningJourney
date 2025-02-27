namespace RapidApi.WebUI.Models
{
    public class HotelDestinationResponseModel
    {

        public class Rootobject
        {
            public bool status { get; set; }
            public string message { get; set; }
            public long timestamp { get; set; }
            public List<Datum> data { get; set; }
        }

        public class Datum
        {
            public string dest_id { get; set; }
            public string search_type { get; set; }
            public string city_name { get; set; }
            public string name { get; set; }
            public string country { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

    }
}
