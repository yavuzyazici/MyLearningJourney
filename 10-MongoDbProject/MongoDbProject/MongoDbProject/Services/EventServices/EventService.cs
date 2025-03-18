using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.DataAccess.Settings;
using MongoDbProject.Dtos.BannerDtos;
using MongoDbProject.Dtos.EventDtos;
using MongoDbProject.Dtos.ServiceDtos;

namespace MongoDbProject.Services.EventServices
{
    public class EventService : IEventService
    {
        private readonly IMongoCollection<Event> _eventCollection;
        private readonly IMapper _mapper;

        public EventService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _eventCollection = database.GetCollection<Event>(databaseSettings.EventCollecionName);
        }

        public async Task CreateAsync(CreateEventDto createEventDto)
        {
            var theEvent = _mapper.Map<Event>(createEventDto);
            await _eventCollection.InsertOneAsync(theEvent);
        }

        public async Task DeleteAsync(string id)
        {
            await _eventCollection.DeleteOneAsync(x => x.EventId == id);
        }

        public async Task<List<ResultEventDto>> GetAllAsync()
        {
            var values = await _eventCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultEventDto>>(values);
        }

        public async Task<UpdateEventDto> GetByIdAsync(string id)
        {
            var value = await _eventCollection.Find(x => x.EventId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateEventDto>(value);
        }

        public async Task UpdateAsync(UpdateEventDto updateEventDto)
        {
            var theEvent = _mapper.Map<Event>(updateEventDto);
            await _eventCollection.FindOneAndReplaceAsync(x => x.EventId == theEvent.EventId, theEvent);
        }
    }
}
