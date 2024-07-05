using AutoMapper;
using D2Store.Business.Services;
using D2Store.Common.DTO.Item;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;
using D2Store.Domain.Entities.Items;
using Moq;
using System.Collections.Generic;

namespace D2Store.Business.Tests.Services
{
    public class ClientItemServiceTests
    {
        private readonly Mock<IClientItemRepository> _clientItemRepository;
        private readonly Mock<IClientRepository> _clientRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly ClientItemService _clientItemService;

        public ClientItemServiceTests()
        {
            _clientItemRepository = new Mock<IClientItemRepository>();
            _clientRepository = new Mock<IClientRepository>();
            _mapper = new Mock<IMapper>();
            _clientItemService = new ClientItemService(_clientItemRepository.Object, _clientRepository.Object, _mapper.Object);
        }

        #region AddClientItemAsync
        [Fact]
        public async Task AddClientItemAsync_Success()
        {
            //Arrange
            ClientItemDTO clientItemDTO = new ClientItemDTO
            {
                ClientId = 1,
                ItemId = 1
            };

            ClientItem clientItem = new ClientItem
            {
                Id = 1,
                ClientId = clientItemDTO.ClientId,
                ItemId = clientItemDTO.ItemId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true
            };

            _mapper.Setup(x => x.Map<ClientItem>(clientItemDTO)).Returns(clientItem);
            _clientItemRepository.Setup(x => x.AddClientItemAsync(clientItem)).Returns(Task.FromResult(clientItem));
            _mapper.Setup(x => x.Map<ClientItemDTO>(clientItem)).Returns(clientItemDTO);

            //Act
            var result = await _clientItemService.AddClientItemAsync(clientItemDTO);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(clientItemDTO.ItemId, result.ItemId);
            Assert.Equal(clientItemDTO.ClientId, result.ClientId);
        }

        [Fact]
        public async Task AddClientItemAsync_Failed()
        {
            //Arrange
            ClientItemDTO clientItemDTO = new ClientItemDTO
            {
                ClientId = 1,
                ItemId = 1
            };

            ClientItem clientItem = new ClientItem
            {
                Id = 1,
                ClientId = clientItemDTO.ClientId,
                ItemId = clientItemDTO.ItemId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true
            };

            string exceptionMsg = "Somthing wrong to add item";


            _mapper.Setup(x => x.Map<ClientItem>(clientItemDTO)).Returns(clientItem);
            _clientItemRepository.Setup(x => x.AddClientItemAsync(clientItem)).Returns(Task.FromResult((ClientItem)null));
            
            //Assert
            var result = await Assert.ThrowsAsync<Exception>(async () => await _clientItemService.AddClientItemAsync(clientItemDTO));

            Assert.Equal(exceptionMsg, result.Message);
        }

        #endregion

        #region UpdateClientItemAsync
        [Fact]
        public async Task UpdateClientItemAsync_Success()
        {
            //Arrange
            ClientItemDTO clientItemDTO = new ClientItemDTO
            {
                ClientId = 4,
                ItemId = 1
            };

            ClientItem clientItem = new ClientItem
            {
                Id = 1,
                ClientId = clientItemDTO.ClientId,
                ItemId = clientItemDTO.ClientId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true
            };

            _mapper.Setup(x => x.Map<ClientItem>(clientItemDTO)).Returns(clientItem);
            _clientItemRepository.Setup(x => x.UpdateClientItemAsync(clientItem)).Returns(Task.FromResult(clientItem));
            _mapper.Setup(x => x.Map<ClientItemDTO>(clientItem)).Returns(clientItemDTO);

            //Act
            var result = await _clientItemService.UpdateClientItemAsync(clientItemDTO);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(clientItemDTO, result);
            Assert.Equal(clientItemDTO.ItemId, result.ItemId);
            Assert.Equal(clientItemDTO.ClientId, result.ClientId);
        }

        [Fact]
        public async Task UpdateClientItemAsync_Failed()
        {
            //Arrange
            ClientItemDTO clientItemDTO = new ClientItemDTO
            {
                ClientId = 1,
                ItemId = 1
            };

            ClientItem clientItem = new ClientItem
            {
                Id = 1,
                ClientId = clientItemDTO.ClientId,
                ItemId = clientItemDTO.ClientId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true
            };

            string exceptionMsg = "Something wrong to update item";

            _mapper.Setup(x => x.Map<ClientItem>(clientItemDTO)).Returns(clientItem);
            _clientItemRepository.Setup(x => x.UpdateClientItemAsync(clientItem)).Returns(Task.FromResult((ClientItem)null));

            //Assert
            var result = await Assert.ThrowsAsync<Exception>(async () => await _clientItemService.UpdateClientItemAsync(clientItemDTO));

            Assert.Equal(exceptionMsg, result.Message);
        }
        #endregion

        #region GetClientItemByIdAsync
        [Fact]
        public async Task GetClientItemByIdAsync_Success()
        {
            int clientItemId = 1;

            ClientItem clientItem = new ClientItem
            {
                Id = clientItemId,
                ClientId = 1,
                ItemId = 1,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true
            };

            ClientItemDTO clientItemDTO = new ClientItemDTO
            {
                ClientId = clientItem.ClientId,
                ItemId = clientItem.ItemId
            };

            _clientItemRepository.Setup(x => x.GetClientItemByIdAsync(clientItemId)).Returns(Task.FromResult(clientItem));
            _mapper.Setup(x => x.Map<ClientItemDTO>(clientItem)).Returns(clientItemDTO);

            //Act
            var result = await _clientItemService.GetClientItemByIdAsync(clientItemId);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetClientItemByIdAsync_Failed()
        {
            //Arrange
            int clientItemId = 1;
            string exceptionMsg = "Client item not found";

            _clientItemRepository.Setup(x => x.GetClientItemByIdAsync(clientItemId)).Returns(Task.FromResult((ClientItem)null));

            //Assert
            var result = await Assert.ThrowsAsync<Exception>(async () => await _clientItemService.GetClientItemByIdAsync(clientItemId));

            Assert.Equal(exceptionMsg, result.Message);
        }
        #endregion

        #region GetAllClientItemsByClientIdAsync
        [Fact]
        public async Task GetAllClientItemsByClientIdAsync_Success()
        {
            //Arrange
            int clientId = 1;

            Client client = new Client()
            {
                Id = clientId,
                Balance = 200,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true
            };

            List<ClientItem> clientItems = new List<ClientItem>
            {
                new ClientItem
                {
                    Id = 1,
                    ClientId = clientId,
                    ItemId = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsActive = true
                },
                new ClientItem
                {
                    Id = 2,
                    ClientId = clientId,
                    ItemId = 2,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsActive = true
                }
            };

            List<ClientItemDTO> clientItemDTOs = new List<ClientItemDTO>
            {
                new ClientItemDTO
                {
                    ClientId = clientItems[0].ClientId,
                    ItemId = clientItems[0].ItemId,
                },
                new ClientItemDTO
                {
                    ClientId = clientItems[1].ClientId,
                    ItemId = clientItems[1].ItemId,
                }
            };

            _clientRepository.Setup(x => x.GetClientByIdAsync(clientId)).Returns(Task.FromResult(client));
            _clientItemRepository.Setup(x => x.GetAllClientItemsByClientIdAsync(clientId)).Returns(Task.FromResult(clientItems));
            _mapper.Setup(x => x.Map<List<ClientItemDTO>>(clientItems)).Returns(clientItemDTOs);

            //Act
            var result = await _clientItemService.GetAllClientItemsByClientIdAsync(clientId);

            //Assert
            Assert.NotNull(client);
            Assert.NotNull(result);
            Assert.Equal(clientItemDTOs.Count, result.Count);
            Assert.Equal(clientItemDTOs[0].ClientId, result[0].ClientId);
            Assert.Equal(clientItemDTOs[0].ItemId, result[0].ItemId);
            Assert.Equal(clientItemDTOs[1].ClientId, result[1].ClientId);
            Assert.Equal(clientItemDTOs[1].ItemId, result[1].ItemId);
        }

        [Fact]
        public async Task GetAllClientItemsByIdAsync_Failed()
        {
            //Arrange
            int clientId = 1;
            string exceptionMsg = "Invalid client id";

            _clientItemRepository.Setup(x => x.GetAllClientItemsByClientIdAsync(clientId)).Returns(Task.FromResult((List<ClientItem>)null));

            //Assert
            var result = await Assert.ThrowsAsync<Exception>(async () => await _clientItemService.GetAllClientItemsByClientIdAsync(clientId));

            Assert.Equal(exceptionMsg, result.Message);
        }
        #endregion

        #region RemoveClientItemByIdAsync
        [Fact]
        public async Task RemoveClientItemByIdAsync_Success()
        {
            //Arrange
            int clientItemId = 1;

            _clientItemRepository.Setup(x => x.RemoveClientItemByIdAsync(clientItemId)).Returns(Task.FromResult(true));

            //Act
            var result = await _clientItemService.RemoveClientItemByIdAsync(clientItemId);

            //Assert
            Assert.True(result);
        }
        #endregion
    }
}
