using AutoMapper;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Item;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Items;

namespace D2Store.Business.Services
{
    public class RequestedItemService : IRequestedItemService
    {
        private readonly IRequestedItemRepository _requestedItemRepository;
        private readonly IMapper _mapper;

        public RequestedItemService(IRequestedItemRepository requestedItemRepository,
            IMapper mapper)
        {
            _requestedItemRepository = requestedItemRepository;
            _mapper = mapper;
        }

        public async Task<RequestedItemDTO> AddRequestedItemAsync(RequestedItemDTO requestedItemDTO)
        {
            var requestedItemToAdd = _mapper.Map<RequestedItem>(requestedItemDTO);

            var addedRequestedItem = await _requestedItemRepository.AddRequestedItemAsync(requestedItemToAdd);

            var result = _mapper.Map<RequestedItemDTO>(addedRequestedItem);

            return result;
        }

        public async Task<RequestedItemDTO> UpdateRequestedItemAsync(RequestedItemDTO requestedItemDTO)
        {
            var requestedItemToUpdate = _mapper.Map<RequestedItem>(requestedItemDTO);

            var updatedRequestedItem = await _requestedItemRepository.UpdateRequestedItemAsync(requestedItemToUpdate);

            var result = _mapper.Map<RequestedItemDTO>(updatedRequestedItem);

            return result;
        }

        public async Task<RequestedItemDTO> GetRequestedItemByIdAsync(int requestedItemId)
        {
            var requestedItem = await _requestedItemRepository.GetRequestedItemByIdAsync(requestedItemId);

            var result = _mapper.Map<RequestedItemDTO>(requestedItem);

            return result;
        }

        public async Task<List<RequestedItemDTO>> GetRequestedItemsByClientIdAsync(int clientId)
        {
            var requestedItems = await _requestedItemRepository.GetRequestedItemsByClientIdAsync(clientId);

            var result = _mapper.Map<List<RequestedItemDTO>>(requestedItems);

            return result;
        }

        public async Task<bool> RemoveRequestedItemByIdAsync(int requestedItemId)
        {
            return await _requestedItemRepository.RemoveRequestedItemByIdAsync(requestedItemId);
        }

        public async Task<bool> RemoveRequestedItemsByClientIdAsync(int clientId)
        {
            var clientRequestItems = await _requestedItemRepository.GetRequestedItemsByClientIdAsync(clientId);

            return await _requestedItemRepository.RemoveRequestedItemsByClientIdAsync(clientRequestItems);
        }
    }
}
