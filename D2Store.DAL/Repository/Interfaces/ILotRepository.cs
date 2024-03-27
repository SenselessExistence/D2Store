using D2Store.Common.DTO.Lot;
using D2Store.Domain.Entities.Lots;

namespace D2Store.DAL.Repository.Interfaces
{
    public interface ILotRepository
    {
        Task<bool> AddLotAsync(Lot lot);

        Task<bool> UpdateLotAsync(Lot lot);

        Task<Lot> GetLotByIdAsync(int id);

        Task<List<Lot>> GetLotsByClientIdAsync(int clientId);

        Task<List<Lot>> GetFilteredLotsAsync(LotFiltersRequestDTO lotFilters);

        Task<bool> RemoveLotByIdAsync(int lotId);

        Task<bool> RemoveAllLotsByClientIdAsync(int clientId);
    }
}
