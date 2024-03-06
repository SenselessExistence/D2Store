using AutoMapper;
using D2Store.Common.DTO.Hero;
using D2Store.Domain.Entities;

namespace D2Store.AutoMapperProfiles
{
    public class HeroMapperProfile : Profile
    {
        public HeroMapperProfile()
        {
            CreateMap<HeroDTO, Hero>();
            CreateMap<Hero, HeroDTO>();
        }
    }
}
