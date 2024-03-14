using AutoMapper;
using D2Store.Business.Services;
using D2Store.Common.DTO.Item;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Items;
using D2Store.Domain.Enumerables;
using Moq;

namespace D2Store.Business.Tests.Services
{
    public class ItemServiceTests
    {
        private readonly Mock<IItemRepository> _itemRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly ItemService _itemService;

        public ItemServiceTests()
        {
            _itemRepository = new Mock<IItemRepository>();
            _mapper = new Mock<IMapper>();
            _itemService = new ItemService(_itemRepository.Object, _mapper.Object);
        }

        #region AddItemAsync
        [Fact]
        public async Task AddItemAsync_Success()
        {
            //Arrange
            ItemDTO itemDTO = new ItemDTO
            {
                ItemName = "Hook",
                Rarity = Rarity.Legendary,
                Description = "Description",
                PictureURL = "PictureURL",
                HeroId = 1
            };

            Item item = new Item
            {
                Id = 1,
                HeroId = itemDTO.HeroId,
                ItemName = itemDTO.ItemName,
                Rarity = itemDTO.Rarity,
                Description = itemDTO.Description,
                PictureURL = itemDTO.PictureURL,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true
            };

            _mapper.Setup(x => x.Map<Item>(itemDTO)).Returns(item);
            _itemRepository.Setup(x => x.AddItemAsync(item)).Returns(Task.FromResult(item));
            _mapper.Setup(x => x.Map<ItemDTO>(item)).Returns(itemDTO);

            //Act
            var result = await _itemService.AddItemAsync(itemDTO);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(itemDTO, result);
            Assert.Equal(itemDTO.ItemName, result.ItemName);
            Assert.Equal(itemDTO.Rarity, result.Rarity);
            Assert.Equal(itemDTO.Description, result.Description);
            Assert.Equal(itemDTO.PictureURL, result.PictureURL);
            Assert.Equal(itemDTO.HeroId, result.HeroId);
        }
        #endregion

        #region UpdateItemAsync
        [Fact]
        public async Task UpdateItemAsync_Success()
        {
            //Arrange
            ItemDTO itemDTO = new ItemDTO
            {
                ItemName = "NeHook",
                Rarity = Rarity.Mythical,
                Description = "Changed",
                PictureURL = "PictureURL-2.0",
                HeroId = 35
            };

            Item item = new Item
            {
                Id = 1,
                HeroId = itemDTO.HeroId,
                ItemName = itemDTO.ItemName,
                Rarity = itemDTO.Rarity,
                Description = itemDTO.Description,
                PictureURL = itemDTO.PictureURL,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true
            };

            _mapper.Setup(x => x.Map<Item>(itemDTO)).Returns(item);
            _itemRepository.Setup(x => x.UpdateItemAsync(item)).Returns(Task.FromResult(item));
            _mapper.Setup(x => x.Map<ItemDTO>(item)).Returns(itemDTO);

            //Act
            var result = await _itemService.UpdateItemAsync(itemDTO);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(itemDTO, result);
            Assert.Equal(itemDTO.ItemName, result.ItemName);
            Assert.Equal(itemDTO.Rarity, result.Rarity);
            Assert.Equal(itemDTO.Description, result.Description);
            Assert.Equal(itemDTO.PictureURL, result.PictureURL);
            Assert.Equal(itemDTO.HeroId, result.HeroId);
        }
        #endregion

        #region GetItemByIdAsync
        [Fact]
        public async Task GetItemByIdAsync()
        {
            //Arrange
            int itemId = 1;

            Item item = new Item
            {
                Id = 1,
                HeroId = 2,
                ItemName = "Hook",
                Rarity = Rarity.Legendary,
                Description = "Test description",
                PictureURL = "Test URL",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true
            };

            ItemDTO itemDTO = new ItemDTO
            {
                ItemName = item.ItemName,
                Rarity = item.Rarity,
                Description = item.Description,
                PictureURL = item.PictureURL,
                HeroId = item.HeroId
            };

            _itemRepository.Setup(x => x.GetItemByIdAsync(itemId)).Returns(Task.FromResult(item));
            _mapper.Setup(x => x.Map<ItemDTO>(item)).Returns(itemDTO);

            //Act
            var result = await _itemService.GetItemByIdAsync(itemId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(itemDTO, result);
            Assert.Equal(itemDTO.ItemName, result.ItemName);
            Assert.Equal(itemDTO.Rarity, result.Rarity);
            Assert.Equal(itemDTO.Description, result.Description);
            Assert.Equal(itemDTO.PictureURL, result.PictureURL);
            Assert.Equal(itemDTO.HeroId, result.HeroId);
        }

        [Fact]
        public async Task GetItemByIdAsync_Failed()
        {
            //Arrange
            int itemId = 1;
            string exceptionMsg = "Item not found";

            _itemRepository.Setup(x => x.GetItemByIdAsync(itemId)).Returns(Task.FromResult((Item)null));

            //Assert
            var result = await Assert.ThrowsAsync<Exception>(async () => await _itemService.GetItemByIdAsync(itemId));

            Assert.Equal(exceptionMsg, result.Message);
        }
        #endregion

        #region RemoveItemByIdAsync
        [Fact]
        public async Task RemoveItemByIdAsync_Success()
        {
            //Arrange
            int itemId = 1;

            _itemRepository.Setup(x => x.RemoveItemByIdAsync(itemId)).Returns(Task.FromResult(true));

            //Act
            var result = await _itemService.RemoveItemByIdAsync(itemId);

            //Assert
            Assert.True(result);
        }
        #endregion
    }
}
