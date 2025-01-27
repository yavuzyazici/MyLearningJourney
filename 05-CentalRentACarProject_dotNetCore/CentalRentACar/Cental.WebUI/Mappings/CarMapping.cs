using AutoMapper;
using Cental.DtoLayer.CarDtos;
using Cental.EntityLayer.Entities;

namespace Cental.WebUI.Mappings
{
    public class CarMapping : Profile
    {
        public CarMapping()
        {
            CreateMap<Car, UICarDto>()
                            .ForMember(dest => dest.Kilometer, opt => opt.MapFrom(src => FormatKilometer(src.Kilometer)))
                            .ReverseMap();
            CreateMap<Car, ResultCarDto>().ReverseMap();
            CreateMap<Car, UpdateCarDto>().ReverseMap();
            CreateMap<Car, CreateCarDto>().ReverseMap();
        }
        private string FormatKilometer(int kilometer)
        {
            if (kilometer >= 1000000)
            {
                return (kilometer / 1000000.0).ToString("0.#") + "M";
            }
            else if (kilometer >= 1000)
            {
                return (kilometer / 1000.0).ToString("0.#") + "K";
            }
            else
            {
                return kilometer.ToString();
            }
        }
    }
}
