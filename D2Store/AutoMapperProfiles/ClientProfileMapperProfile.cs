using AutoMapper;
using D2Store.Common.DTO.ClientProfile.ClientProfileResponse;
using D2Store.Common.DTO.ClientProfile.Service;
using D2Store.Domain.Entities;

namespace D2Store.AutoMapperProfiles
{
    public class ClientProfileMapperProfile : Profile
    {
        public ClientProfileMapperProfile()
        {
            CreateMap<ClientProfileDTO, CreateClientProfileResponse>();

            CreateMap<ClientProfileDTO, UpdateClientProfileResponse>();

            CreateMap<ClientProfile, ClientProfileDTO>();

            CreateMap<ClientProfileDTO, GetClientProfileResponse>();
        }
    }
}
