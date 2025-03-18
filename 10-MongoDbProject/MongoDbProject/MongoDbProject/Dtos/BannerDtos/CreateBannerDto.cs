namespace MongoDbProject.Dtos.BannerDtos
{
    public class CreateBannerDto
    {
        public string UpperTitle { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
