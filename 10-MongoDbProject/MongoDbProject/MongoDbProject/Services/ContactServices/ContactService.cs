using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.DataAccess.Settings;
using MongoDbProject.Dtos.BannerDtos;
using MongoDbProject.Dtos.ContactDtos;

namespace MongoDbProject.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollecionName);
        }
        public async Task CreateAsync(CreateContactDto createContactDto)
        {
            var contact = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(contact);
        }

        public async Task DeleteAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            var values = await _contactCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<UpdateContactDto> GetByIdAsync(string id)
        {
            var value = await _contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateContactDto>(value);
        }

        public async Task UpdateAsync(UpdateContactDto updateContactDto)
        {
            var contact = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == contact.ContactId, contact);
        }
    }
}
