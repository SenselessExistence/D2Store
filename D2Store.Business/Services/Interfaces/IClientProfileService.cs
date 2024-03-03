using D2Store.Common.DTO.ClientProfile.Service;

namespace D2Store.Business.Services.Interfaces
{
    public interface IClientProfileService
    {
        Task<ClientProfileDTO> AddClientProfileAsync(ClientProfileDTO profileDTO);

        Task<ClientProfileDTO> UpdateClientProfileAsync(ClientProfileDTO profileDTO);

        Task<ClientProfileDTO> GetClientProfileByIdAsync(int id);

        Task<bool> RemoveClientProfileByIdAsync(int id);
    }
}
