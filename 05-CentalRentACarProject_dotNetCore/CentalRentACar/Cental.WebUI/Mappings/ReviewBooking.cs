using AutoMapper;
using Cental.DtoLayer.ReviewDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class ReviewBooking : Profile
    {
        public ReviewBooking()
        {
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>().ReverseMap();
            CreateMap<Review, ResultReviewDto>().ReverseMap();
            CreateMap<Review, ResultReviewDto>().ReverseMap();
            CreateMap<ResultReviewDto, Booking>().ReverseMap();
            CreateMap<CreateReviewDto, Booking>().ReverseMap();
        }
    }
}
