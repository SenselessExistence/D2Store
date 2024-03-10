using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Items;
using Microsoft.EntityFrameworkCore;

namespace D2Store.DAL.Repository
{
    public class ClientItemRepository : BaseRepository<ClientItem>, IClientItemRepository
    {
        public ClientItemRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<ClientItem> AddClientItemAsync(ClientItem clientItem)
        {
            return await AddAsync(clientItem);
        }

        public async Task<ClientItem> UpdateClientItemAsync(ClientItem clientItem)
        {
            return await UpdateAsync(clientItem);
        }

        public async Task<ClientItem> GetClientItemByIdAsync(int clientItemId)
        {
            return await GetByIdAsync(clientItemId);
        }

        public async Task<List<ClientItem>> GetAllClientItemsByClientIdAsync(int clientId)
        {
            return await _context.ClientItems.Where(ci => ci.ClientId == clientId).ToListAsync();
        }

        public async Task<bool> RemoveClientItemByIdAsync(int clientItemId)
        {
            return await RemoveByIdAsync(clientItemId);
        }
    }
}
