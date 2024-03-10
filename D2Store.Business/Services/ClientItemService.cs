using AutoMapper;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Item;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Items;

namespace D2Store.Business.Services
{
    public class ClientItemService : IClientItemService
    {
        private readonly IClientItemRepository _clientItemRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientItemService(IClientItemRepository clientItemRepository,
            IClientRepository clientRepository,
            IMapper mapper)
        {
            _clientItemRepository = clientItemRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ClientItemDTO> AddClientItemAsync(ClientItemDTO clientItemDTO)
        {
            var itemToAdd = _mapper.Map<ClientItem>(clientItemDTO);

            var addedItem = await _clientItemRepository.AddClientItemAsync(itemToAdd);

            if(addedItem == null)
            {
                throw new Exception("Somthing wrong to add item");
            }

            var result = _mapper.Map<ClientItemDTO>(addedItem);

            return result;
        }

        public async Task<ClientItemDTO> UpdateClientItemAsync(ClientItemDTO clientItemDTO)
        {
            var itemToUpdate = _mapper.Map<ClientItem>(clientItemDTO);

            var updatedItem = await _clientItemRepository.UpdateClientItemAsync(itemToUpdate);

            if(updatedItem == null)
            {
                throw new Exception("Something wrong to update item");
            }

            var result = _mapper.Map<ClientItemDTO>(updatedItem);

            return result;
        }

        public async Task<ClientItemDTO> GetClientItemByIdAsync(int clientItemId)
        {
            var clientItem = await _clientItemRepository.GetClientItemByIdAsync(clientItemId);

            if(clientItem == null)
            {
                throw new Exception("Client item not found");
            }

            var result = _mapper.Map<ClientItemDTO>(clientItem);

            return result;
        }

        public async Task<List<ClientItemDTO>> GetAllClientItemsByClientIdAsync(int clientId)
        {
            var checkClient = await _clientRepository.GetClientByIdAsync(clientId);
            
            if(checkClient == null)
            {
                throw new Exception("Invalid client id");
            }

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
