using D2Store.Common.DTO.Cart;
using D2Store.Common.DTO.Lot;

namespace D2Store.Business.Services.Interfaces
{
    public interface ICartLotService
    {
        Task<bool> AddLotToCartAsync(CartLotDTO lotToAdd);

        Task<List<CartLotDTO>> GetAllCartLotsByClientIdAsync(int clientId);

        Task<bool> RemoveLotFromCartByIdAsync(int lotId);

        Task<bool> RemoveAllLotsFromCartByClientIdAsync(int clientId);
    }
}
