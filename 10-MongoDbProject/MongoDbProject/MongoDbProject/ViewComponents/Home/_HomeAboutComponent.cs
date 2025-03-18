using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.AboutDtos;
using MongoDbProject.Services.AboutServices;

namespace MongoDbProject.ViewComponents.Home
{
    public class _HomeAboutComponent(IAboutService _aboutService, IMapper _mapper) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _aboutService.GetAllAsync();
            var about = _mapper.Map<ResultAboutDto>(value.FirstOrDefault());
            return View(about);
        }
    }
}
