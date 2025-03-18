namespace MongoDbProject.Dtos.BannerDtos
{
    public class UpdateBannerDto
    {
        public string BannerId { get; set; }
        public string UpperTitle { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
