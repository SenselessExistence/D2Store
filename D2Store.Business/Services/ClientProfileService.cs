using AutoMapper;
using Castle.Core.Logging;
using D2Store.Business.Exceptions;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.ClientProfile;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace D2Store.Business.Services
{
    public class ClientProfileService : IClientProfileService
    {
        private readonly IClientProfileRepository _clientProfileRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientProfileService> _logger;

        public ClientProfileService(IClientProfileRepository clientProfileRepository,
            IMapper mapper,
            ILogger<ClientProfileService> logger)
        {
            _clientProfileRepository = clientProfileRepository;
            _mapper = mapper;
            _logger = logger;
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

        public async Task<ClientProfileDTO> GetClientProfileByIdAsync(int profileId)
        {
            var profile = await _clientProfileRepository.GetClientProfileByIdAsync(profileId);

            profile.ThrowIfNull("profile", _logger, $"Profile with ID: {profileId} does not exist!");

            return _mapper.Map<ClientProfileDTO>(profile);
        }

        public async Task<bool> RemoveClientProfileByIdAsync(int profileId)
        {
            return await _clientProfileRepository.RemoveClientProfileByIdAsync(profileId);
        }

        #region Private methods
        private void UpdateProfileData(ClientProfile clientProfile, ClientProfileDTO profileDTO)
        {
            clientProfile.FirstName = profileDTO.FirstName;
            clientProfile.LastName = profileDTO.LastName;
            clientProfile.PhoneNumber = profileDTO.PhoneNumber;
            clientProfile.About = profileDTO.About;
            clientProfile.Nickname = profileDTO.Nickname;
        }
        #endregion
    }
}
