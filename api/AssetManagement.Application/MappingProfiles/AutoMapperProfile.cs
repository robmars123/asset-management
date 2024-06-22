using AssetManagement.Application.Models.Assets.Queries;
using AssetManagement.Domain.Entities;
using AutoMapper;

namespace AssetManagement.Application.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Asset, AssetRequestResult>();
        }
        
    }
}
