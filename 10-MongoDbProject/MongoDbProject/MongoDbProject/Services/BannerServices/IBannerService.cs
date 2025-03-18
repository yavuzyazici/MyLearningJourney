using MongoDbProject.Dtos.BannerDtos;
using MongoDbProject.Dtos.InstructorDtos;

namespace MongoDbProject.Services.BannerServices
{
    public interface IBannerService
    {
        Task<List<ResultBannerDto>> GetAllAsync();
        Task<UpdateBannerDto> GetByIdAsync(string id);
        Task CreateAsync(CreateBannerDto createBannerDto);
        Task UpdateAsync(UpdateBannerDto updateBannerDto);
        Task DeleteAsync(string id);
    }
}