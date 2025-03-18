using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDbProject.Dtos.TestimonialDtos;
using MongoDbProject.Services.TestimonialServices;

namespace MongoDbProject.ViewComponents.Home
{
    public class _HomeTestimonialComponent(ITestimonialService _testimonialService, IMapper _mapper) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _testimonialService.GetAllAsync();
            var testimonial = _mapper.Map<List<ResultTestimonialDto>>(value);
            return View(testimonial);
        }
    }
}
