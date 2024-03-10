using D2Store.Domain.Entities.Items;

namespace D2Store.DAL.Repository.Interfaces
{
    public interface IClientItemRepository
    {
        Task<ClientItem> AddClientItemAsync(ClientItem clientItem);

        Task<ClientItem> UpdateClientItemAsync(ClientItem clientItem);

        Task<ClientItem> GetClientItemByIdAsync(int clientItemId);

        Task<List<ClientItem>> GetAllClientItemsByClientIdAsync(int clientId);

        Task<bool> RemoveClientItemByIdAsync(int clientItemId);
    }
}
