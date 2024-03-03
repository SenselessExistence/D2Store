using D2Store.Common.DTO.Cart;
using D2Store.Domain.Entities.Lots;

namespace D2Store.DAL.Repository.Interfaces
{
    public interface ICartLotRepository
    {
        Task<CartLot> AddLotToCartAsync(CartLot cartLot);

        Task<bool> RemoveLotFromCartAsync(int lotId);

        Task<bool> RemoveAllLotsFromCartAsync(int clientId);

        Task<List<CartLotDTO>> GetAllCartLotsByClientIdAsync(int clientId);
    }
}
