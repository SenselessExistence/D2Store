using AutoMapper;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Client;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;

namespace D2Store.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository,
            IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientDTO> AddClientAsync (ClientDTO clientDTO)
        {
            var clientToAdd = _mapper.Map<Client>(clientDTO);

            var client = await _clientRepository.AddClientAsync(clientToAdd);

            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<ClientDTO> UpdateClientAsync(ClientDTO clientDTO)
        {
            var clientToUpdate = _mapper.Map<Client>(clientDTO);

            var client = await _clientRepository.UpdateClientAsync(clientToUpdate);

            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<ClientDTO> GetClientByIdAsync(int id)
        {
            var client = await _clientRepository.GetClientByIdAsync(id);

            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<bool> RemoveClientByIdAsync(int id)
        {
            return await _clientRepository.RemoveClientByIdAsync(id);
        }
    }
}
