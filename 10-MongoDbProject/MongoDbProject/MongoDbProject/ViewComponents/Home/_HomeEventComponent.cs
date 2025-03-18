using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.EventDtos;
using MongoDbProject.Services.EventServices;

namespace MongoDbProject.ViewComponents.Home
{
    public class _HomeEventComponent(IEventService _eventService, IMapper _mapper) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _eventService.GetAllAsync();
            var about = _mapper.Map<List<ResultEventDto>>(value.Take(3));
            return View(about);
        }
    }
}
