using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.DataAccess.Settings;
using MongoDbProject.Dtos.BannerDtos;
using MongoDbProject.Dtos.InstructorDtos;

namespace MongoDbProject.Services.BannerServices
{
    public class BannerService : IBannerService
    {
        private readonly IMongoCollection<Banner> _bannerCollection;
        private readonly IMapper _mapper;

        public BannerService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bannerCollection = database.GetCollection<Banner>(databaseSettings.BannerCollecionName);
        }
        public async Task CreateAsync(CreateBannerDto createBannerDto)
        {
            var banner = _mapper.Map<Banner>(createBannerDto);
            await _bannerCollection.InsertOneAsync(banner);
        }

        public async Task DeleteAsync(string id)
        {
            await _bannerCollection.DeleteOneAsync(x => x.BannerId == id);
        }

        public async Task<List<ResultBannerDto>> GetAllAsync()
        {
            var values = await _bannerCollection.AsQueryable().ToListAsync();
            return _mapper.Map<List<ResultBannerDto>>(values);
        }

        public async Task<UpdateBannerDto> GetByIdAsync(string id)
        {
            var value = await _bannerCollection.Find(x => x.BannerId == id).FirstOrDefaultAsync();
            return _mapper.Map<UpdateBannerDto>(value);
        }

        public async Task UpdateAsync(UpdateBannerDto updateBannerDto)
        {
            var banner = _mapper.Map<Banner>(updateBannerDto);
            await _bannerCollection.FindOneAndReplaceAsync(x => x.BannerId == banner.BannerId, banner);
        }
    }
}
