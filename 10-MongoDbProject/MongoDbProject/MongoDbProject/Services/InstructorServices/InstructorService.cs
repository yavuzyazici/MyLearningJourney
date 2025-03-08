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

        public async Task CreateInstructorAsync(CreateInstructorDto createInstructorDto)
        {
            var instructor = _mapper.Map<Instructor>(createInstructorDto);
            await _instructorCollection.InsertOneAsync(instructor);
        }

        public async Task DeleteInstructorAsync(string id)
        {
            await _instructorCollection.DeleteOneAsync(x=>x.InstructorId == id);
        }

        public async Task<List<ResultInstructorDto>> GetAllInstructorAsync()
        {
            var values = await _instructorCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultInstructorDto>>(values);
        }

        public async Task<UpdateInstructorDto> GetInstructorByIdAsync(string id)
        {
            var value = await _instructorCollection.Find(x=>x.InstructorId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateInstructorDto>(value);
        }

        public async Task UpdateInstructorAsync(UpdateInstructorDto updateInstructorDto)
        {
            var instructor = _mapper.Map<Instructor>(updateInstructorDto);
            await _instructorCollection.FindOneAndReplaceAsync(x => x.InstructorId == instructor.InstructorId, instructor);
        }
    }
}
