using AutoMapper;
using D2Store.Common.DTO.Item;
using D2Store.Domain.Entities.Items;

namespace D2Store.AutoMapperProfiles
{
    public class RequestedItemMapperProfile : Profile
    {
        public RequestedItemMapperProfile()
        {
            CreateMap<RequestedItem, RequestedItemDTO>();
            CreateMap<RequestedItemDTO, RequestedItem>();
        }
    }
}
