using AutoMapper;
using D2Store.Common.DTO.Item;
using D2Store.Domain.Entities.Items;

namespace D2Store.AutoMapperProfiles
{
    public class ClientItemMapperProfile : Profile
    {
        public ClientItemMapperProfile()
        {
            CreateMap<ClientItemDTO, ClientItem>();
            CreateMap<ClientItem, ClientItemDTO>();
        }
    }
}
