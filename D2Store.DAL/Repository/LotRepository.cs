using D2Store.Common.DTO.Lot;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Items;
using D2Store.Domain.Entities.Lots;
using Microsoft.EntityFrameworkCore;

namespace D2Store.DAL.Repository
{
    public class LotRepository : BaseRepository<Lot>, ILotRepository
    {
        public LotRepository(DataContext context) 
            : base(context)
        {
            
        }


        public async Task<bool> AddLotAsync(Lot lot)
        {
            await AddAsync(lot);

            return true;
        }

        public async Task<bool> UpdateLotAsync(Lot lot)
        {
            await UpdateAsync(lot);
            return true;
        }

        public async Task<List<Lot>> GetLotsByClientIdAsync(int clientId)
        {
            var clientLots = await _context.Lots
                .Where(l => l.SellerClientId == clientId)
                .ToListAsync();

            return clientLots;
        }

        public async Task<List<Lot>> GetFilteredLots(LotFiltersRequestDTO lotFilters)
        {
            var query = _context.Lots.AsQueryable();

            if (!string.IsNullOrEmpty(lotFilters.HeroName))
            {
                query = query.Include(l => l.ClientItem)
                    .ThenInclude(ci => ci.Item)
                    .ThenInclude(i => i.Hero)
                    .Where(l => l.ClientItem.Item.Hero.HeroName.Contains(lotFilters.HeroName));
                    
            }

            if (!string.IsNullOrEmpty(lotFilters.ItemName))
            {
                query = query.Include(l => l.ClientItem)
                    .ThenInclude(ci => ci.Item)
                    .Where(l => l.ClientItem.Item.ItemName.Contains(lotFilters.ItemName));
            }

            if (lotFilters.MinPrice.HasValue)
            {
                query = query.Where(l => l.Price >= lotFilters.MinPrice.Value);
            }
            
            if(lotFilters.MaxPrice.HasValue)
            {
                query = query.Where(l => l.Price <= lotFilters.MaxPrice.Value);
            }

            if(lotFilters.Rarity.HasValue)
            {
                query = query.Include(l => l.ClientItem)
                    .ThenInclude(ci => ci.Item)
                    .Where(l => l.ClientItem.Item.Rarity == lotFilters.Rarity);
                    
            }

            return await query.ToListAsync();
        }
        
        public async Task<Lot> GetLotByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<bool> RemoveLotByIdAsync(int lotId)
        {
            return await RemoveByIdAsync(lotId);
        }

        public async Task<bool> RemoveAllLotsByClientIdAsync(int clientId)
        {
            var clientLots = await _context.Lots.Include(c => c.ClientItem)
                .Where(c => c.ClientItem.ClientId == clientId)
                .ToListAsync();

            _context.Lots.RemoveRange(clientLots);

            return true;
        }
    }
}