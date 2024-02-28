using D2Store.Common.DTO.Cart;
using D2Store.Common.DTO.Lot;

namespace D2Store.Business.Services.Interfaces
{
    public interface ICartLotService
    {
        Task<bool> AddLotToCartAsync(LotDTO lot, int clientId);

        Task<List<CartLotDTO>> GetAllCartLotsByClientIdAsync(int clientId);

        Task<bool> RemoveLotFromCartByIdAsync(int lotId);

        Task<bool> RemoveAllLotsFromCartByClientIdAsync(int clientId);
    }
}
