using AutoMapper;
using Cental.DtoLayer.TestimonialDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ManagerResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UITestimonialDto>().ReverseMap();
        }
    }
}
