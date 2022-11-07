using AutoMapper;
using Services.Catalog.Dtos.FeatureDtos;
using Services.Catalog.Models;

namespace Services.Catalog.MappingProfiles
{
    public class FeatureProfile:Profile
    {
        public FeatureProfile()
        {
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
