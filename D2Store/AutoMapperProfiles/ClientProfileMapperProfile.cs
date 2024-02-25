using AutoMapper;
using D2Store.Common.DTO.ClientProfile.ClientProfileRequest;
using D2Store.Common.DTO.ClientProfile.ClientProfileResponse;
using D2Store.Common.DTO.ClientProfile.Service;
using D2Store.Domain.Entities;

namespace D2Store.AutoMapperProfiles
{
    public class ClientProfileMapperProfile : Profile
    {
        public ClientProfileMapperProfile()
        {
            CreateMap<CreateClientProfileRequest, ClientProfileDTO>();
            CreateMap<ClientProfileDTO, CreateClientProfileResponse>();

            CreateMap<UpdateClientProfileRequest, ClientProfileDTO>();
            CreateMap<ClientProfileDTO, UpdateClientProfileResponse>();

            CreateMap<ClientProfileDTO, ClientProfile>();
            CreateMap<ClientProfile, ClientProfileDTO>();

            CreateMap<ClientProfileDTO, GetClientProfileResponse>();
        }
    }
}
