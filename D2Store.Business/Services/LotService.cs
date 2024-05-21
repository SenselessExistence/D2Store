using AutoMapper;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO;
using D2Store.Common.DTO.Lot;
using D2Store.DAL.Extensions;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Lots;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2Store.Business.Services
{
    public class LotService : ILotService
    {
        private readonly ILotRepository _lotRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IClientItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public LotService(ILotRepository lotRepository,
            IMapper mapper,
            IClientRepository clientRepository,
            IClientItemRepository clientItemRepository)
        {
            _lotRepository = lotRepository;
            _mapper = mapper;
            _clientRepository = clientRepository;
            _itemRepository = clientItemRepository;
        }

        public async Task<bool> AddLotAsync(LotDTO lot)
        {
            var lotToAdd = _mapper.Map<Lot>(lot);

            return await _lotRepository.AddLotAsync(lotToAdd);
        }

        public async Task<bool> UpdateLotAsync(LotDTO lot)
        {
            var lotToUpdate = _mapper.Map<Lot>(lot);

            return await _lotRepository.UpdateLotAsync(lotToUpdate);
        }

        public async Task<List<LotDTO>> GetLotsByClientIdAsync(int clientId)
        {
            var lots = await _lotRepository.GetLotsByClientIdAsync(clientId);

            if(lots.Count == 0)
            {
                throw new Exception("Client dont have lots");
            }

            return _mapper.Map<List<LotDTO>>(lots);
        }

        public async Task<LotDTO> GetLotByIdAsync(int lotId)
        {
            var lot = await _lotRepository.GetLotByIdAsync(lotId);

            if (lot == null)
            {
                throw new Exception("Lot not found");
            }

            return _mapper.Map<LotDTO>(lot);
        }

        public async Task<List<LotDTO>> GetFilteredLotsAsync(LotFiltersRequestDTO lotFilters)
        {
            var filteredLots = await _lotRepository.GetFilteredLotsAsync(lotFilters);

            var result = _mapper.Map<List<LotDTO>>(filteredLots);

            return result;
        }

        public async Task<PagedResponse<LotDTO>> GetPagedLotsAsync(int page, int pageSize)
        {
            var totalCount = await _lotRepository.GetLotsCountAsync();

            var lots = await _lotRepository.GetLotsQueryable()
                                     .Paginate(page, pageSize)
                                     .ToListAsync();

            var lotDTOs = _mapper.Map<List<LotDTO>>(lots);

            var response = new PagedResponse<LotDTO>
            {
                Data = lotDTOs,
                TotalCount = totalCount
            };

            return response;
        }

        public async Task<bool> BuyLotAsync(BuyLotRequestDTO buyLotRequestDTO)
        {
            var user = await _clientRepository.GetClientByIdAsync(buyLotRequestDTO.BuyerId);

            var lot = await _lotRepository.GetLotByIdAsync(buyLotRequestDTO.LotId);

            var item = await _itemRepository.GetClientItemByIdAsync(lot.ClientItemId);

            if (!lot.IsActive)
            {
                throw new Exception("Lot is not active.");
            }

            if(user.Balance < lot.Price)
            {
                throw new Exception("Insufficient funds on account.");
            }

            user.Balance -= lot.Price;
            await _clientRepository.UpdateClientAsync(user);

            item.ClientId = buyLotRequestDTO.BuyerId;
            await _itemRepository.UpdateClientItemAsync(item);

            lot.SellDate = DateTime.Now;
            lot.IsActive = false;
            await _lotRepository.UpdateLotAsync(lot);

            return true;
        }

        public async Task<bool> RemoveLotByIdAsync(int lotId)
        {
             var result = await _lotRepository.RemoveLotByIdAsync(lotId);

            if(result == false)
            {
                throw new Exception("Failed to remove");
            }

            return result;
        }

        public async Task<bool> RemoveAllLotsByClientIdAsync(int clientId)
        {
            var result = await _lotRepository.RemoveAllLotsByClientIdAsync(clientId);

            if(result == false)
            {
                throw new Exception("Failed to remove");
            }

            return result;
        }
    }
}
