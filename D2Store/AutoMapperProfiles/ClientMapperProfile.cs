using AutoMapper;
using D2Store.Common.DTO.Client;
using D2Store.Domain.Entities;

namespace D2Store.AutoMapperProfiles
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<ClientDTO, Client>();
            CreateMap<Client, ClientDTO>();
        }
    }
}
