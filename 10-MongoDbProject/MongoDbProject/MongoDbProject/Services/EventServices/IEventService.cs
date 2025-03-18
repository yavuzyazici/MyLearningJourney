using MongoDbProject.Dtos.EventDtos;

namespace MongoDbProject.Services.EventServices
{
    public interface IEventService
    {
        Task<List<ResultEventDto>> GetAllAsync();
        Task<UpdateEventDto> GetByIdAsync(string id);
        Task CreateAsync(CreateEventDto createEventDto);
        Task UpdateAsync(UpdateEventDto updateEventDto);
        Task DeleteAsync(string id);
    }
}
