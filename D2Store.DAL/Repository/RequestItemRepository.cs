using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Items;
using Microsoft.EntityFrameworkCore;

namespace D2Store.DAL.Repository
{
    public class RequestItemRepository : BaseRepository<RequestedItem>, IRequestedItemRepository
    {
        public RequestItemRepository(DataContext context)
            :base(context)
        {
            
        }

        public async Task<RequestedItem> AddRequestedItemAsync(RequestedItem requestedItem)
        {
            return await AddAsync(requestedItem);
        }

        public async Task<RequestedItem> UpdateRequestedItemAsync(RequestedItem requestedItem)
        {
            return await UpdateAsync(requestedItem);
        }

        public async Task<RequestedItem> GetRequestedItemByIdAsync(int requestedItemId)
        {
            return await GetByIdAsync(requestedItemId);
        }

        public async Task<List<RequestedItem>> GetRequestedItemsByClientIdAsync(int clientId)
        {
            return await _context.RequestItems.Where(ri => ri.ClientId == clientId).ToListAsync();
        }

        public async Task<bool> RemoveRequestedItemByIdAsync(int requestedItemId)
        {
            return await RemoveByIdAsync(requestedItemId);
        }

        public async Task<bool> RemoveRequestedItemsByClientIdAsync(int clientId)
        {
            var requestedItems = await _context.RequestItems.Where(ri => ri.ClientId == clientId)
                .ToListAsync();

            _context.RemoveRange(requestedItems);

            return true;
        }
    }
}
