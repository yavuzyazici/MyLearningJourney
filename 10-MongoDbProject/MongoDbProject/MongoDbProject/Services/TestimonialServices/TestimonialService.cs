using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.DataAccess.Settings;
using MongoDbProject.Dtos.BannerDtos;
using MongoDbProject.Dtos.TestimonialDtos;

namespace MongoDbProject.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;

        public TestimonialService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollecionName);
        }

        public async Task CreateAsync(CreateTestimonialDto createTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            await _testimonialCollection.InsertOneAsync(testimonial);
        }

        public async Task DeleteAsync(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x => x.TestimonialId == id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllAsync()
        {
            var values = await _testimonialCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultTestimonialDto>>(values);
        }

        public async Task<UpdateTestimonialDto> GetByIdAsync(string id)
        {
            var value = await _testimonialCollection.Find(x => x.TestimonialId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateTestimonialDto>(value);
        }

        public async Task UpdateAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            var testimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            await _testimonialCollection.FindOneAndReplaceAsync(x => x.TestimonialId == testimonial.TestimonialId, testimonial);
        }
    }
}
