using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Items;
using D2Store.Domain.Entities.Lots;
using Microsoft.EntityFrameworkCore;

namespace D2Store.DAL.Repository
{
    public class LotRepository : BaseRepository<Lot>, ILotRepository
    {

        public LotRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<List<Lot>> GetLotsByClientIdAsync(int clientId)
        {
            var clientLots = await _context.Lots.Where(l => l.SellerClientId == clientId).ToListAsync();

            return clientLots;
        }

        public async Task<bool> CreateLotAsync(Lot lot)
        {
            await AddAsync(lot);

            return true;
        }

        public async Task<bool> UpdateLotByIdAsync(Lot lot)
        {
            await UpdateAsync(lot);
            return true;
        }

        public async Task<Lot> GetLotByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteLotByIdAsync(int lotId)
        {
            return await RemoveByIdAsync(lotId);
        }

        public async Task<bool> DeleteAllLotsByClientIdAsync(int clientId)
        {
            var clientLots = await _context.Lots.Where(c => c.ClientItem.ClientId == clientId).ToListAsync();

            _context.Lots.RemoveRange(clientLots);

            return true;
        }
    }
}
