using AutoMapper;
using Cental.DtoLayer.BookingDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class BookingMapping : Profile
    {
        public BookingMapping()
        {
            CreateMap<Booking, UIBookingDto>()
                .ForMember(dest => dest.PickUpTime, opt => opt.MapFrom(src => TimeOnly.FromDateTime(src.PickUpDate)))
                .ForMember(dest => dest.DropOffTime, opt => opt.MapFrom(src => TimeOnly.FromDateTime(src.DropOffDate)))
                .ReverseMap()
                .ForMember(dest => dest.PickUpDate, opt => opt.MapFrom(src => src.PickUpDate.Add(src.PickUpTime.ToTimeSpan())))
                .ForMember(dest => dest.DropOffDate, opt => opt.MapFrom(src => src.DropOffDate.Add(src.DropOffTime.ToTimeSpan())));
            CreateMap<Booking, ManagerPanelBookingDto>().ReverseMap();
            CreateMap<Booking, UserPanelBookingDto>().ReverseMap();
            CreateMap<Booking, ApproveBookingDto>().ReverseMap();
        }
    }
}