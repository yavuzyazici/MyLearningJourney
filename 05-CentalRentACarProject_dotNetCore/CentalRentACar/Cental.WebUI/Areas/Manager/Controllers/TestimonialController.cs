using AutoMapper;
using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.TestimonialDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class TestimonialController(ITestimonialService _testimonialService, IMapper _mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = _testimonialService.TGetAll();
            var testimonials = _mapper.Map<List<ManagerResultTestimonialDto>>(data);
            return View(testimonials);
        }
        [HttpGet]
        public IActionResult ApproveTestimonial(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            testimonial.IsAproved = !testimonial.IsAproved;
            _testimonialService.TUpdate(testimonial);
            return RedirectToAction("Index", new {area = "Manager"});
        }
    }
}