using D2Store.Domain.Entities;

namespace D2Store.DAL.Repository.Interfaces
{
    public interface IClientProfileRepository
    {
        Task<ClientProfile> CreateProfileAsync(ClientProfile profile);

        Task<ClientProfile> UpdateClientProfileAsync(ClientProfile profile);

        Task<ClientProfile> GetClientProfileByIdAsync(int id);

        Task<bool> RemoveClientProfileByIdAsync(int id);
    }
}
