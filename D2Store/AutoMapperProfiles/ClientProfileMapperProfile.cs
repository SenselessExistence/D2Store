using AutoMapper;
using D2Store.Common.DTO.ClientProfile;
using D2Store.Domain.Entities;

namespace D2Store.AutoMapperProfiles
{
    public class ClientProfileMapperProfile : Profile
    {
        public ClientProfileMapperProfile()
        {
            CreateMap<ClientProfile, ClientProfileDTO>();
        }
    }
}
