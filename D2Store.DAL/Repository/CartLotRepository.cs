using D2Store.Common.DTO.Cart;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Items;
using D2Store.Domain.Entities.Lots;
using Microsoft.EntityFrameworkCore;

namespace D2Store.DAL.Repository
{
    public class CartLotRepository : BaseRepository<CartLot>, ICartLotRepository
    {
        public CartLotRepository(DataContext context) 
            : base(context)
        {
            
        }

        public async Task<bool> AddLotToCartAsync(CartLot lot)
        {
            await AddAsync(lot);

            return true;
        }

        public async Task<bool> RemoveLotFromCartAsync(int lotId)
        {
            var lotToRemove = await _context.CartLots.FindAsync(lotId);

            _context.CartLots.Remove(lotToRemove); 
            await _context.SaveChangesAsync(); 

            return true; 
        }

        public async Task<bool> RemoveAllLotsFromCartAsync (int clientId)
        {
            var allLots = await _context.CartLots.Where(l => l.ClientId == clientId).ToListAsync();

            foreach (var lot in allLots)
            {
                 _context.CartLots.Remove(lot);
            }
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CartLotDTO>> GetAllCartLotsByClientIdAsync(int clientId)
        {
            var sortedLots = await _context.CartLots
                .Where(cl => cl.ClientId == clientId)
                .Join(_context.Lots,
                    cl => cl.LotId,
                    l => l.Id,
                    (cl, l) => l)
                .Join(_context.ClientItems,
                l => l.ClientItemId,
                ci => ci.Id,
                (l, ci) => new { Lot = l, OwnedItem = ci })
                .Join(_context.Items,
                ci => ci.OwnedItem.ItemId,
                i => i.Id,
                (ci, i) => new { Item = i, Lot = ci.Lot })
                .Select(dto => new CartLotDTO
                {
                    PictureURL = dto.Item.PictureURL,
                    ItemName = dto.Item.ItemName,
                    Price = dto.Lot.Price,
                    LotId = dto.Lot.Id
                })
                .ToListAsync();

            return sortedLots;
        }
    }
}
