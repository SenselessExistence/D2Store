using AutoMapper;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Cart;
using D2Store.Common.DTO.Lot;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Lots;

namespace D2Store.Business.Services
{
    public class CartLotService : ICartLotService
    {
        private readonly ICartLotRepository _cartLotRepository;

        public CartLotService(ICartLotRepository cartLotRepository)
        {
            _cartLotRepository = cartLotRepository;
        }

        public async Task<bool> AddLotToCartAsync(CartLotDTO cartLotDTO)
        {
            var lotToAdd = new CartLot()
            {
                ExpectedPrice = cartLotDTO.Price,
                ClientId = cartLotDTO.ClientId,
                LotId = cartLotDTO.LotId,
            };

            await _cartLotRepository.AddLotToCartAsync(lotToAdd);

            return true;
        }

        public async Task<List<CartLotDTO>> GetAllCartLotsByClientIdAsync(int clientId)
        {
            return await _cartLotRepository.GetAllCartLotsByClientIdAsync(clientId);
        }

        public async Task<bool> RemoveLotFromCartByIdAsync(int lotId)
        {
            return await _cartLotRepository.RemoveLotFromCartAsync(lotId);
        }

        public async Task<bool> RemoveAllLotsFromCartByClientIdAsync(int clientId)
        {
            return await _cartLotRepository.RemoveAllLotsFromCartAsync(clientId);
        }
    }
}
