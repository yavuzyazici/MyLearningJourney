using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.InstructorDtos;
using MongoDbProject.Services.InstructorServices;

namespace MongoDbProject.ViewComponents.Home
{
    public class _HomeInstructorComponent(IInstructorService _instructorService, IMapper _mapper) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _instructorService.GetAllAsync();
            var instructor = _mapper.Map<List<ResultInstructorDto>>(value.Take(4));
            return View(instructor);
        }
    }
}
