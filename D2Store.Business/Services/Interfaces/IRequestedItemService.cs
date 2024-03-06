using D2Store.Common.DTO.Item;

namespace D2Store.Business.Services.Interfaces
{
    public interface IRequestedItemService
    {
        Task<RequestedItemDTO> AddRequestedItemAsync(RequestedItemDTO requestedItemDTO);

        Task<RequestedItemDTO> UpdateRequestedItemAsync(RequestedItemDTO requestedItemDTO);

        Task<RequestedItemDTO> GetRequestedItemByIdAsync(int requestedItemId);

        Task<List<RequestedItemDTO>> GetRequestedItemsByClientIdAsync(int clientId);

        Task<bool> RemoveRequestedItemByIdAsync(int requestedItemId);

        Task<bool> RemoveRequestedItemsByClientIdAsync(int clientId);
    }
}