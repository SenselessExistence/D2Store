using AutoMapper;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Item;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Items;

namespace D2Store.Business.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository,
            IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemDTO> AddItemAsync(ItemDTO itemDTO)
        {
            var itemToAdd = _mapper.Map<Item>(itemDTO);

            var createdItem = await _itemRepository.AddItemAsync(itemToAdd);

            var result = _mapper.Map<ItemDTO>(createdItem);

            return result;
        }

        public async Task<ItemDTO> UpdateItemAsync(ItemDTO itemDTO)
        {
            var itemToUpdate = _mapper.Map<Item>(itemDTO);

            var updatedItem = await _itemRepository.UpdateItemAsync(itemToUpdate);

            var result = _mapper.Map<ItemDTO>(updatedItem);

            return result;
        }

        public async Task<ItemDTO> GetItemByIdAsync(int itemId)
        {
            var item = await _itemRepository.GetItemByIdAsync(itemId);

            if(item == null)
            {
                throw new Exception($"Item with ID {itemId} not found!");
            }

            var result = _mapper.Map<ItemDTO>(item);

            return result;
        }

        public async Task<bool> RemoveItemByIdAsync(int itemId)
        {
            return await _itemRepository.RemoveItemByIdAsync(itemId);
        }
    }
}
