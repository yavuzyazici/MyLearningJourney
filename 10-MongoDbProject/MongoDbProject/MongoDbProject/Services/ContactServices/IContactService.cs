using MongoDbProject.Dtos.ContactDtos;

namespace MongoDbProject.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllAsync();
        Task<UpdateContactDto> GetByIdAsync(string id);
        Task CreateAsync(CreateContactDto createContactDto);
        Task UpdateAsync(UpdateContactDto updateContactDto);
        Task DeleteAsync(string id);
    }
}
