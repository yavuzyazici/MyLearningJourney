using MongoDbProject.Dtos.ServiceDtos;

namespace MongoDbProject.Services.ServiceServices
{
    public interface IServiceService
    {
        Task<List<ResultServiceDto>> GetAllAsync();
        Task<UpdateServiceDto> GetByIdAsync(string id);
        Task CreateAsync(CreateServiceDto createServiceDto);
        Task UpdateAsync(UpdateServiceDto updateServiceDto);
        Task DeleteAsync(string id);
    }
}