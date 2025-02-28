namespace RapidApi.WebUI.Models
{
    public class ImdbViewModel
    {
        public List<Movie> Movies { get; set; }


        public class Movie
        {
            public string id { get; set; }
            public string url { get; set; }
            public string primaryTitle { get; set; }
            public string originalTitle { get; set; }
            public string type { get; set; }
            public string description { get; set; }
            public string primaryImage { get; set; }
            public string contentRating { get; set; }
            public int startYear { get; set; }
            public object endYear { get; set; }
            public string releaseDate { get; set; }
            public string[] interests { get; set; }
            public string[] countriesOfOrigin { get; set; }
            public string[] externalLinks { get; set; }
            public string[] spokenLanguages { get; set; }
            public string[] filmingLocations { get; set; }
            public Productioncompany[] productionCompanies { get; set; }
            public long? budget { get; set; }
            public long? grossWorldwide { get; set; }
            public string[] genres { get; set; }
            public bool isAdult { get; set; }
            public int runtimeMinutes { get; set; }
            public float averageRating { get; set; }
            public int numVotes { get; set; }
        }

        public class Productioncompany
        {
            public string id { get; set; }
            public string name { get; set; }
        }

    }
}
