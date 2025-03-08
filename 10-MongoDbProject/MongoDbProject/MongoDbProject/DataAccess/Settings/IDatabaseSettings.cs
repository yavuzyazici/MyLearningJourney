namespace MongoDbProject.DataAccess.Settings
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string InstructorCollecionName { get; set; }
        public string ProductCollecionName { get; set; }
    }
}
