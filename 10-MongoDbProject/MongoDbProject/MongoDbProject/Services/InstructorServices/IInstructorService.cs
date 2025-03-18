using MongoDbProject.Dtos.InstructorDtos;

namespace MongoDbProject.Services.InstructorServices
{
    public interface IInstructorService
    {
        Task<List<ResultInstructorDto>> GetAllAsync();
        Task<UpdateInstructorDto> GetByIdAsync(string id);
        Task<ResultInstructorDto> GetByNameAsync(string name);
        Task CreateAsync(CreateInstructorDto createInstructorDto);
        Task UpdateAsync(UpdateInstructorDto updateInstructorDto);
        Task DeleteAsync(string id);
    }
}