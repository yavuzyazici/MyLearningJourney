using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.ServiceDtos;
using MongoDbProject.Services.ServiceServices;

namespace MongoDbProject.ViewComponents.Home
{
    public class _HomeServiceComponent(IServiceService _serviceService, IMapper _mapper) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _serviceService.GetAllAsync();
            var service = _mapper.Map<List<ResultServiceDto>>(value.Take(4));
            return View(service);
        }
    }
}
