using AutoMapper;
using Services.Catalog.Dtos.CourseDtos;
using Services.Catalog.Models;

namespace Services.Catalog.MappingProfiles
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
        }
    }
}
