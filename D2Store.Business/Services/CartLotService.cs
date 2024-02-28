using AutoMapper;
using D2Store.Common.DTO.Cart;
using D2Store.Common.DTO.Lot;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Lots;

namespace D2Store.Business.Services
{
    public class CartLotService
    {
        private readonly ICartLotRepository _cartLotRepository;
        private readonly IMapper _mapper;

        public CartLotService(ICartLotRepository cartLotRepository,
            IMapper mapper)
        {
            _cartLotRepository = cartLotRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddLotToCartAsync(LotDTO lot, int clientId)
        {
            var lotToAdd = _mapper.Map<Lot>(lot);

            await _cartLotRepository.AddLotToCartAsync(lotToAdd, clientId);

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
