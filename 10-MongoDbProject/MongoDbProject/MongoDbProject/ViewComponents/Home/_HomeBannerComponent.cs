using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.BannerDtos;
using MongoDbProject.Services.BannerServices;

namespace MongoDbProject.ViewComponents.Home
{
    public class _HomeBannerComponent(IBannerService _bannerService, IMapper _mapper) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value =  await _bannerService.GetAllAsync();
            var banner = _mapper.Map<ResultBannerDto>(value.FirstOrDefault());
            return View(banner);
        }
    }
}
