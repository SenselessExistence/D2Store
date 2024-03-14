using D2Store.Common.DTO.Lot;
using D2Store.Domain.Entities.Lots;

namespace D2Store.Business.Services.Interfaces
{
    public interface ILotService
    {
        Task<bool> AddLotAsync(LotDTO lot);

        Task<bool> UpdateLotAsync(LotDTO lot);

        Task<List<LotDTO>> GetLotsByClientIdAsync(int clientId);

        Task<LotDTO> GetLotByIdAsync(int lotId);

        Task<bool> RemoveLotByIdAsync(int lotId);

        Task<bool> RemoveAllLotsByClientIdAsync(int clientId);
    }
}
