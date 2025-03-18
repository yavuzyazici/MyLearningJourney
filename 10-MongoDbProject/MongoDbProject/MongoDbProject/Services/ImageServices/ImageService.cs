using System.ComponentModel.DataAnnotations;

namespace MongoDbProject.Services.ImageServices
{
    public class ImageService : IImageService
    {
        public async Task<string> SaveImageAsync(IFormFile file)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
            {
                throw new ValidationException("Image format is invalid");
            }

            var imageName = Guid.NewGuid() + extension;

            var destination = Path.Combine(currentDirectory, "wwwroot/images");
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }
            var saveLocation = Path.Combine(destination, imageName);

            var stream = new FileStream(saveLocation, FileMode.Create);
            await file.CopyToAsync(stream);
            return "/images/" + imageName;
        }
    }
}
