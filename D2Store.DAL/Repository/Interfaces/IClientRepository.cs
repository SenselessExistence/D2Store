using D2Store.Domain.Entities;

namespace D2Store.DAL.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> AddClientAsync(Client client);

        Task<Client> UpdateClientAsync(Client client);
        
        Task<Client> GetClientByIdAsync(int id);
        
        Task<bool> RemoveClientByIdAsync(int id);

    }
}
