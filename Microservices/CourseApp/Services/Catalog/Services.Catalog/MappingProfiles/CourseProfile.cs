using AutoMapper;
using Services.Catalog.Dtos.CourseDtos;
using Services.Catalog.Models;

namespace Services.Catalog.MappingProfiles
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
        }
    }
}
