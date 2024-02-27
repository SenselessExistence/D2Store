using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Items;

namespace D2Store.DAL.Repository
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(DataContext context) : base(context) { }

        public async Task<Item> AddItemAsync(Item item)
        {
            return await AddAsync(item);
        }

        public async Task<Item> UpdateItemAsync(Item item)
        {
            return await UpdateAsync(item);
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<bool> RemoveItemByIdAsync(int id)
        {
            return await RemoveByIdAsync(id);
        }
    }
}
