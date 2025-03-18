namespace MongoDbProject.Services.ImageServices
{
    public interface IImageService
    {
        /// <summary>
        /// Saves an image file from the computer to the web app. As a path saves to /wwwroot/images/
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Returns a string value for the image that created as ImageUrl</returns>
        Task<string> SaveImageAsync(IFormFile file);
    }
}
