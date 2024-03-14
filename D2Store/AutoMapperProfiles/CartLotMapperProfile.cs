using AutoMapper;
using D2Store.Common.DTO.Cart;
using D2Store.Domain.Entities.Lots;

namespace D2Store.AutoMapperProfiles
{
    public class CartLotMapperProfile : Profile
    {
        public CartLotMapperProfile()
        {
            CreateMap<CartLot, CartLotDTO>();
            CreateMap<CartLotDTO, CartLot>();
        }
    }
}
