using AutoMapper;
using MongoDbProject.DataAccess.Entities;
using MongoDbProject.Dtos.InstructorDtos;

namespace MongoDbProject.Mappings
{
    public class InstructorMapping : Profile
    {
        public InstructorMapping()
        {
            CreateMap<ResultInstructorDto,Instructor>().ReverseMap();
            CreateMap<UpdateInstructorDto,Instructor>().ReverseMap();
            CreateMap<CreateInstructorDto,Instructor>().ReverseMap();
        }
    }
}