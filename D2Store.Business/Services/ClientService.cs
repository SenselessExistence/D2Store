using AutoMapper;
using D2Store.Business.Exceptions;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Client;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace D2Store.Business.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientService> _logger;

        public ClientService(IClientRepository clientRepository,
            IMapper mapper,
            ILogger<ClientService> logger)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _logger = logger;
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

        public async Task<ClientDTO> GetClientByIdAsync(int clientId)
        {
            var client = await _clientRepository.GetClientByIdAsync(clientId);

            client.ThrowIfNull("client", _logger, $"Client with ID: {client} does not exist!");

            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<bool> RemoveClientByIdAsync(int clientId)
        {
            return await _clientRepository.RemoveClientByIdAsync(clientId);
        }
    }
}
