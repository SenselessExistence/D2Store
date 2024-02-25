using AutoMapper;
using D2Store.Common.DTO.Client;
using D2Store.Common.DTO.Client.Request;
using D2Store.Common.DTO.Client.Response;
using D2Store.Domain.Entities;

namespace D2Store.AutoMapperProfiles
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            CreateMap<AddClientRequest, ClientDTO>();
            CreateMap<ClientDTO, AddClientResponse>();

            CreateMap<UpdateClientRequest, ClientDTO>();
            CreateMap<ClientDTO, UpdateClientResponse>();

            CreateMap<ClientDTO, Client>();
            CreateMap<Client, ClientDTO>();

            CreateMap<ClientDTO, GetClientByIdResponse>();
        }
    }
}
