using MongoDbProject.Dtos.TestimonialDtos;

namespace MongoDbProject.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllAsync();
        Task<UpdateTestimonialDto> GetByIdAsync(string id);
        Task CreateAsync(CreateTestimonialDto createTestimonialDto);
        Task UpdateAsync(UpdateTestimonialDto updateTestimonialDto);
        Task DeleteAsync(string id);
    }
}
