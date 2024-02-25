using D2Store.Common.DTO.ClientProfile.Service;

namespace D2Store.Business.Services.Interfaces
{
    public interface IClientProfileService
    {
        Task<ClientProfileDTO> CreateClientProfile(ClientProfileDTO profileDTO);

        Task<ClientProfileDTO> UpdateClientProfile(ClientProfileDTO profileDTO);

        Task<ClientProfileDTO> GetClientProfileById(int id);

        Task<bool> DeleteClientProfileByIdAsync(int id);
    }
}
