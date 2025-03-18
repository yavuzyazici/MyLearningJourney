using AutoMapper;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.Dtos.EventDtos;

namespace MongoDbProject.Mappings
{
    public class EventMapping : Profile
    {
        public EventMapping()
        {
            CreateMap<ResultEventDto, Event>().ReverseMap();
            CreateMap<CreateEventDto, Event>().ReverseMap();
            CreateMap<UpdateEventDto, Event>().ReverseMap();
        }
    }
}
