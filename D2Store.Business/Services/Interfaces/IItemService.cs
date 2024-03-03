using D2Store.Common.DTO.Item;

namespace D2Store.Business.Services.Interfaces
{
    public interface IItemService
    {
        Task<ItemDTO> AddItemAsync(ItemDTO itemDTO);

        Task<ItemDTO> UpdateItemAsync(ItemDTO itemDTO);

        Task<ItemDTO> GetItemByIdAsync(int itemId);

        Task<bool> RemoveItemByIdAsync(int itemId);
    }
}
