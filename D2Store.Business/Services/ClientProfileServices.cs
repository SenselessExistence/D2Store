using AutoMapper;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.ClientProfile.Service;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;

namespace D2Store.Business.Services
{
    public class ClientProfileServices : IClientProfileService
    {
        private readonly IClientProfileRepository _clientProfileRepository;
        private readonly IMapper _mapper;

        public ClientProfileServices(IClientProfileRepository clientProfileRepository,
            IMapper mapper)
        {
            _clientProfileRepository = clientProfileRepository;
            _mapper = mapper;
        }

        public async Task<ClientProfileDTO> AddClientProfileAsync(ClientProfileDTO profileDTO)
        {
            var profileToCreate = _mapper.Map<ClientProfile>(profileDTO);

            var profile = await _clientProfileRepository.CreateProfileAsync(profileToCreate);

            return _mapper.Map<ClientProfileDTO>(profile);
        }

        public async Task<ClientProfileDTO> UpdateClientProfileAsync(ClientProfileDTO profileDTO)
        {
            var profileToUpdate = await _clientProfileRepository.GetClientProfileByIdAsync(profileDTO.ClientId);
            
            UpdateProfileData(profileToUpdate, profileDTO);

            var updatedProfile = await _clientProfileRepository.UpdateClientProfileAsync(profileToUpdate);

            return _mapper.Map<ClientProfileDTO>(updatedProfile);
        }

        public async Task<ClientProfileDTO> GetClientProfileByIdAsync(int id)
        {
            var profile = await _clientProfileRepository.GetClientProfileByIdAsync(id);

            return _mapper.Map<ClientProfileDTO>(profile);
        }

        public async Task<bool> RemoveClientProfileByIdAsync(int id)
        {
            return await _clientProfileRepository.RemoveClientProfileByIdAsync(id);
        }

        private void UpdateProfileData(ClientProfile clientProfile, ClientProfileDTO profileDTO)
        {
            clientProfile.FirstName = profileDTO.FirstName;
            clientProfile.LastName = profileDTO.LastName;
            clientProfile.PhoneNumber = profileDTO.PhoneNumber;
            clientProfile.Birthday = profileDTO.Birthday;
            clientProfile.About = profileDTO.About;
            clientProfile.Nickname = profileDTO.Nickname;
        }
    }
}
