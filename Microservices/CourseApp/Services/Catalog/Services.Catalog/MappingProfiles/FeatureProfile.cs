using AutoMapper;
using MongoDB.Driver.Core.Misc;
using Services.Catalog.Dtos.FeatureDtos;

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
