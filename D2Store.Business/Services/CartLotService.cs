using AutoMapper;
using D2Store.Business.Exceptions;
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
        private readonly IMapper _mapper;

        public CartLotService(ICartLotRepository cartLotRepository, IMapper mapper)
        {
            _cartLotRepository = cartLotRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddLotToCartAsync(CartLotDTO cartLotDTO)
        {
            var cartLotToAdd = _mapper.Map<CartLot>(cartLotDTO);

            return await _cartLotRepository.AddLotToCartAsync(cartLotToAdd);
        }

        public async Task<List<CartLotDTO>> GetAllCartLotsByClientIdAsync(int clientId)
        {
            var cartLots = await _cartLotRepository.GetAllCartLotsByClientIdAsync(clientId);

            var result = _mapper.Map<List<CartLotDTO>>(cartLots);

            return result;
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
