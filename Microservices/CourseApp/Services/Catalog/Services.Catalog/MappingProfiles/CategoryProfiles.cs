using AutoMapper;
using Services.Catalog.Dtos.CategoryDtos;
using Services.Catalog.Models;

namespace Services.Catalog.MappingProfiles
{
    public class CategoryProfiles:Profile
    {
        public CategoryProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>();
        }
    }
}
