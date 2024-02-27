using D2Store.Common.DTO.Cart;
using D2Store.Domain.Entities.Items;
using D2Store.Domain.Entities.Lots;
using Microsoft.EntityFrameworkCore;

namespace D2Store.DAL.Repository
{
    public class CartLotRepository : BaseRepository<CartLot>
    {
        public CartLotRepository(DataContext context) : base(context)
        {
            
        }

        public async Task<CartLot> AddLotToCartAsync(CartLot cartLot)
        {
            return await AddAsync(cartLot);
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

        public async Task<List<CartLotDTO>> GetAllCartLots(int clientId)
        {
            var sortedLots = await _context.CartLots
                .Where(cl => cl.ClientId == clientId)
                .Join(_context.Lots,
                    cl => cl.LotId,
                    l => l.Id,
                    (cl, l) => l)
                .Join(_context.OwnedItems,
                l => l.ClientItemId,
                oi => oi.Id,
                (l, oi) => new { Lot = l, OwnedItem = oi })
                .Join(_context.Items,
                oi => oi.OwnedItem.ItemId,
                i => i.Id,
                (oi, i) => new { Item = i, Lot = oi.Lot })
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
