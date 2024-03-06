using AutoMapper;
using D2Store.Common.DTO.Item;
using D2Store.Domain.Entities.Items;

namespace D2Store.AutoMapperProfiles
{
    public class ItemMapperProfile : Profile
    {
        public ItemMapperProfile()
        {
            CreateMap<ItemDTO, Item>();
            CreateMap<Item, ItemDTO>();
        }
    }
}
