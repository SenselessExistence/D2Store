using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;

namespace D2Store.DAL.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(DataContext context) : base(context) {  }

        public async Task<Client> AddClientAsync(Client client)
        {
            return await AddAsync(client);
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            return await UpdateAsync(client);
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<bool> RemoveClientByIdAsync(int id)
        {
            return await RemoveByIdAsync(id);
        }
    }
}
