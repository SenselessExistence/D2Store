using AutoMapper;
using D2Store.Business.Exceptions;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Item;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Items;
using Microsoft.Extensions.Logging;

namespace D2Store.Business.Services
{
    public class ClientItemService : IClientItemService
    {
        private readonly IClientItemRepository _clientItemRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientItemService> _logger;

        public ClientItemService(IClientItemRepository clientItemRepository,
            IClientRepository clientRepository,
            IMapper mapper,
            ILogger<ClientItemService> logger)
        {
            _clientItemRepository = clientItemRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ClientItemDTO> AddClientItemAsync(ClientItemDTO clientItemDTO)
        {
            var itemToAdd = _mapper.Map<ClientItem>(clientItemDTO);

            var addedItem = await _clientItemRepository.AddClientItemAsync(itemToAdd);

            var result = _mapper.Map<ClientItemDTO>(addedItem);

            return result;
        }

        public async Task<ClientItemDTO> UpdateClientItemAsync(ClientItemDTO clientItemDTO)
        {
            var itemToUpdate = _mapper.Map<ClientItem>(clientItemDTO);

            var updatedItem = await _clientItemRepository.UpdateClientItemAsync(itemToUpdate);

            var result = _mapper.Map<ClientItemDTO>(updatedItem);

            return result;
        }

        public async Task<ClientItemDTO> GetClientItemByIdAsync(int clientItemId)
        {
            var clientItem = await _clientItemRepository.GetClientItemByIdAsync(clientItemId);

            clientItem.ThrowIfNull("clientItem", _logger, $"The item with ID: {clientItemId} does not exist!");

            var result = _mapper.Map<ClientItemDTO>(clientItem);

            return result;
        }

        public async Task<List<ClientItemDTO>> GetAllClientItemsByClientIdAsync(int clientId)
        {
            var checkClient = await _clientRepository.GetClientByIdAsync(clientId);

            checkClient.ThrowIfNull("checkClient", _logger, $"The client with ID: {clientId} does not exist!");

            var clientItems = await _clientItemRepository.GetAllClientItemsByClientIdAsync(clientId);

            var result = _mapper.Map<List<ClientItemDTO>>(clientItems);

            return result;
        }

        public async Task<bool> RemoveClientItemByIdAsync(int clientItemId)
        {
            return await _clientItemRepository.RemoveClientItemByIdAsync(clientItemId);
        }
    }
}
