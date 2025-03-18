using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.DataAccess.Settings;
using MongoDbProject.Dtos.AboutDtos;
using MongoDbProject.Dtos.ServiceDtos;

namespace MongoDbProject.Services.ServiceServices
{
    public class ServiceService : IServiceService
    {
        private readonly IMongoCollection<Service> _serviceCollection;
        private readonly IMapper _mapper;

        public ServiceService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _serviceCollection = database.GetCollection<Service>(databaseSettings.ServiceCollecionName);
        }
        public async Task CreateAsync(CreateServiceDto createServiceDto)
        {
            var service = _mapper.Map<Service>(createServiceDto);
            await _serviceCollection.InsertOneAsync(service);
        }

        public async Task DeleteAsync(string id)
        {
            await _serviceCollection.DeleteOneAsync(x => x.ServiceId == id);
        }

        public async Task<List<ResultServiceDto>> GetAllAsync()
        {
            var values = await _serviceCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultServiceDto>>(values);
        }

        public async Task<UpdateServiceDto> GetByIdAsync(string id)
        {
            var value = await _serviceCollection.Find(x => x.ServiceId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateServiceDto>(value);
        }

        public async Task UpdateAsync(UpdateServiceDto updateServiceDto)
        {
            var service = _mapper.Map<Service>(updateServiceDto);
            await _serviceCollection.FindOneAndReplaceAsync(x => x.ServiceId == service.ServiceId, service);
        }
    }
}
