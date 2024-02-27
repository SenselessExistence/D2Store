using D2Store.Domain.Entities.Items;

namespace D2Store.DAL.Repository.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> AddItemAsync(Item item);

        Task<Item> UpdateItemAsync(Item item);

        Task<Item> GetItemByIdAsync(int id);

        Task<bool> RemoveItemByIdAsync(int id);
    }
}
