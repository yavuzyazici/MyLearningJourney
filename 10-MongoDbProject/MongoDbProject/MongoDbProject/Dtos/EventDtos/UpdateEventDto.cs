namespace MongoDbProject.Dtos.EventDtos
{
    public class UpdateEventDto
    {
        public string EventId { get; set; }
        public string ShortDate { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
    }
}
