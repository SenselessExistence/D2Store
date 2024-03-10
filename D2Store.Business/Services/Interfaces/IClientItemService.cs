using D2Store.Common.DTO.Item;

namespace D2Store.Business.Services.Interfaces
{
    public interface IClientItemService
    {
        Task<ClientItemDTO> AddClientItemAsync(ClientItemDTO clientItemDTO);

        Task<ClientItemDTO> UpdateClientItemAsync(ClientItemDTO clientItemDTO);

        Task<ClientItemDTO> GetClientItemByIdAsync(int clientItemId);

        Task<List<ClientItemDTO>> GetAllClientItemsByClientIdAsync(int clientId);

        Task<bool> RemoveClientItemByIdAsync(int clientItemId);
    }
}
