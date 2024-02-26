using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;

namespace D2Store.DAL.Repository
{
    public class ClientProfileRepository : BaseRepository<ClientProfile>, IClientProfileRepository
    {
        public ClientProfileRepository(DataContext context) : base(context) { }
        
        public async Task<ClientProfile> CreateProfileAsync(ClientProfile profile)
        {
            return await AddAsync(profile);
        }

        public async Task<ClientProfile> UpdateClientProfileAsync(ClientProfile profile)
        {
            return await UpdateAsync(profile);
        }

        public async Task<ClientProfile> GetClientProfileByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<bool> DeleteClientProfileByIdAsync(int id)
        {
            return await RemoveByIdAsync(id);
        }
    }
}
