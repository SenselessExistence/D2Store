using AutoMapper;
using D2Store.Common.DTO.Lot;
using D2Store.Domain.Entities.Lots;

namespace D2Store.AutoMapperProfiles
{
    public class LotMapperProfile : Profile
    {
        public LotMapperProfile()
        {
            CreateMap<Lot, LotDTO>();
            CreateMap<LotDTO, Lot>();
        }
    }
}
