namespace MongoDbProject.DataAccess.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string InstructorCollecionName { get; set; }
        public string ProductCollecionName { get; set; }
        public string BannerCollecionName { get; set; }
        public string AboutCollecionName { get; set; }
        public string ServiceCollecionName { get; set; }
        public string EventCollecionName { get; set; }
        public string TestimonialCollecionName { get; set; }
        public string ContactCollecionName { get; set; }
    }
}
