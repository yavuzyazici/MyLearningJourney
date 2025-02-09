using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.ViewComponents.Default
{
    public class _DefaultTestimonialComponent(ITestimonialService _testimonialService, IMapper _mapper) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var data = _testimonialService.TGetAll().Where(x => x.IsAproved == true);
            var testimonials = _mapper.Map<List<UITestimonialDto>>(data);
            return View(testimonials);
        }
    }
}
