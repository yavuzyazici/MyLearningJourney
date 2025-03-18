using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.DataAccess.Settings;
using MongoDbProject.Dtos.InstructorDtos;

namespace MongoDbProject.Services.InstructorServices
{
    public class InstructorService : IInstructorService
    {
        private readonly IMongoCollection<Instructor> _instructorCollection;
        private readonly IMapper _mapper;

        public InstructorService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _instructorCollection = database.GetCollection<Instructor>(databaseSettings.InstructorCollecionName);
        }

        public async Task CreateAsync(CreateInstructorDto createInstructorDto)
        {
            var instructor = _mapper.Map<Instructor>(createInstructorDto);
            await _instructorCollection.InsertOneAsync(instructor);
        }

        public async Task DeleteAsync(string id)
        {
            await _instructorCollection.DeleteOneAsync(x => x.InstructorId == id);
        }

        public async Task<List<ResultInstructorDto>> GetAllAsync()
        {
            var values = await _instructorCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultInstructorDto>>(values);
        }

        public async Task<UpdateInstructorDto> GetByIdAsync(string id)
        {
            var value = await _instructorCollection.Find(x => x.InstructorId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateInstructorDto>(value);
        }

        public async Task<ResultInstructorDto> GetByNameAsync(string name)
        {
            var value = await _instructorCollection.Find(x => x.FirstName + " " + x.LastName == name).FirstOrDefaultAsync();
            return _mapper.Map<ResultInstructorDto>(value);
        }

        public async Task UpdateAsync(UpdateInstructorDto updateInstructorDto)
        {
            var instructor = _mapper.Map<Instructor>(updateInstructorDto);
            await _instructorCollection.FindOneAndReplaceAsync(x => x.InstructorId == instructor.InstructorId, instructor);
        }
    }
}
