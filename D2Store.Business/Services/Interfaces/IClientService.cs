using D2Store.Common.DTO.Client;
using D2Store.Domain.Entities;

namespace D2Store.Business.Services.Interfaces
{
    public interface IClientService
    {
        Task<ClientDTO> AddClientAsync(ClientDTO clientDTO);

        Task<ClientDTO> UpdateClientAsync(ClientDTO clientDTO);

        Task<ClientDTO> GetClientByIdAsync(int id);

        Task<bool> RemoveClientByIdAsync(int id);
    }
}
