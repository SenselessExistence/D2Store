using D2Store.Domain.Entities.Items;

namespace D2Store.DAL.Repository.Interfaces
{
    public interface IRequestedItemRepository
    {
        Task<RequestedItem> AddRequestedItemAsync(RequestedItem requestedItem);

        Task<RequestedItem> UpdateRequestedItemAsync(RequestedItem requestedItem);

        Task<RequestedItem> GetRequestedItemByIdAsync(int requestedItemId);

        Task<List<RequestedItem>> GetRequestedItemsByClientIdAsync(int clientId);

        Task<bool> RemoveRequestedItemByIdAsync(int requestedItemId);

        Task<bool> RemoveRequestedItemsByClientIdAsync(List<RequestedItem> requestedItems);
    }
}
