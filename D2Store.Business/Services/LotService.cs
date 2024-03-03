using AutoMapper;
using D2Store.Common.DTO.Lot;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Lots;

namespace D2Store.Business.Services
{
    public class LotService
    {
        private readonly ILotRepository _lotRepository;
        private readonly IMapper _mapper;

        public LotService(ILotRepository lotRepository,
            IMapper mapper)
        {
            _lotRepository = lotRepository;
            _mapper = mapper;
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

            return _mapper.Map<List<LotDTO>>(lots);
        }

        public async Task<LotDTO> GetLotByIdAsync(int lotId)
        {
            var lot = await _lotRepository.GetLotByIdAsync(lotId);

            return _mapper.Map<LotDTO>(lot);
        }

        public async Task<bool> RemoveLotByIdAsync(int lotId)
        {
            return await _lotRepository.RemoveLotByIdAsync(lotId);
        }

        public async Task<bool> RemoveAllLotsByClientId(int clientId)
        {
            return await _lotRepository.RemoveAllLotsByClientIdAsync(clientId);
        }
    }
}
