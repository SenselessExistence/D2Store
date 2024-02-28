using D2Store.Domain.Entities.Lots;

namespace D2Store.DAL.Repository.Interfaces
{
    public interface ILotRepository
    {
        Task<bool> CreateLotAsync(Lot lot);

        Task<bool> UpdateLotByIdAsync(Lot lot);

        Task<Lot> GetLotByIdAsync(int id);

        Task<List<Lot>> GetLotsByClientIdAsync(int clientId);

        Task<bool> DeleteLotByIdAsync(int lotId);

        Task<bool> DeleteAllLotsByClientIdAsync(int clientId);
    }
}
