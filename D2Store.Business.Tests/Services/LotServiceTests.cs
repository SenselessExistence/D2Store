using AutoMapper;
using D2Store.Business.Services;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Lot;
using D2Store.DAL.Repository;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Lots;
using Moq;

namespace D2Store.Business.Tests.Services
{
    public class LotServiceTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILotRepository> _lotRepository;
        private readonly Mock<IClientRepository> _clientRepository;
        private readonly Mock<IClientItemRepository> _itemRepository;
        private readonly LotService _lotService;

        public LotServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _lotRepository = new Mock<ILotRepository>();
            _clientRepository = new Mock<IClientRepository>();
            _itemRepository = new Mock<IClientItemRepository>();
            _lotService = new LotService(_lotRepository.Object, _mapper.Object, _clientRepository.Object, _itemRepository.Object);
        }

        #region AddLotAsync
        [Fact]
        public async Task AddLotAsync_Success()
        {
            //Arrange
            var lotDTO = new LotDTO
            {
                ClientItemId = 1,
                Price = 200,
                SellerClientId = 1
            };

            Lot lot = new Lot()
            {
                Id = 1,
                ClientItemId = lotDTO.ClientItemId,
                Price = lotDTO.Price,
                SellerClientId = lotDTO.SellerClientId,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            _mapper.Setup(x => x.Map<Lot>(lotDTO)).Returns(lot);
            _lotRepository.Setup(x => x.AddLotAsync(lot)).Returns(Task.FromResult(true));

            //Act

            var result = await _lotService.AddLotAsync(lotDTO);

            //Assert
            
            Assert.True(result);

        }
        #endregion

        #region UpdateLotAsync
        [Fact]
        public async Task UpdateLotAsync_Success()
        {
            //Arrange
            var lotDTO = new LotDTO
            {
                ClientItemId = 2,
                Price = 250,
                SellerClientId = 2
            };

            var lot = new Lot
            {
                ClientItemId = lotDTO.ClientItemId,
                Price = lotDTO.Price,
                SellerClientId = lotDTO.SellerClientId,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            _mapper.Setup(x => x.Map<Lot>(lotDTO)).Returns(lot);
            _lotRepository.Setup(x => x.UpdateLotAsync(lot)).Returns(Task.FromResult(true));

            //Act
            var result = await _lotService.UpdateLotAsync(lotDTO);

            //Assert
            Assert.True(result);
        }

        #endregion

        #region GetLotByIAsync
        [Fact]
        public async Task GetLotByIdAsync_Success()
        {
            //Arrange
            int id = 1;

            Lot lot = new Lot
            {
                Id = 1,
                ClientItemId = 1,
                Price = 200,
                SellerClientId = 1,
                IsActive = true,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            LotDTO lotDTO = new LotDTO
            {
                ClientItemId = lot.ClientItemId,
                Price = lot.Price
            };

            _lotRepository.Setup(x => x.GetLotByIdAsync(id)).Returns(Task.FromResult(lot));
            _mapper.Setup(x => x.Map<LotDTO>(lot)).Returns(lotDTO);

            //Act
            var result = await _lotService.GetLotByIdAsync(id);

            //Assert
            Assert.Equal(lotDTO, result);
            Assert.Equal(lotDTO.Price, result.Price);
            Assert.Equal(lotDTO.ClientItemId, result.ClientItemId);
        }

        [Fact]
        public async Task GetLotByIdAsync_NotFound_Exception()
        {
            //Arrange
            int id = 1;
            string exceptionMsg = "Lot not found";

            _lotRepository.Setup(x => x.GetLotByIdAsync(id)).ReturnsAsync((Lot)null);

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(async () => await _lotService.GetLotByIdAsync(id));

            Assert.Equal(exceptionMsg, exception.Message);
        }
        #endregion

        #region GetLotsByClientIdAsync
        [Fact]
        public async Task GetLotsByClientIdAsync_Success()
        {
            //Arrange
            int clientId = 1;

            List<Lot> lots = new List<Lot>()
            {
                new Lot
                {
                    Id = 1,
                    ClientItemId = 1,
                    Price = 200,
                    SellerClientId = clientId,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                },
                new Lot
                {
                    Id = 2,
                    ClientItemId = 2,
                    Price = 400,
                    SellerClientId = clientId,
                    IsActive = true,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow
                }
            };

            List<LotDTO> lotsDTO = new List<LotDTO>
            {
                new LotDTO
                {
                    ClientItemId = lots[0].ClientItemId,
                    Price = lots[0].Price,
                    SellerClientId = lots[0].SellerClientId
                },
                new LotDTO
                {
                    ClientItemId = lots[1].ClientItemId,
                    Price = lots[1].Price,
                    SellerClientId = lots[1].SellerClientId
                }
            };

            _mapper.Setup(x => x.Map<List<LotDTO>>(lots)).Returns(lotsDTO);
            _lotRepository.Setup(x => x.GetLotsByClientIdAsync(clientId)).Returns(Task.FromResult(lots));

            //Act
            var result = await _lotService.GetLotsByClientIdAsync(clientId);

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(lots.Count(), result.Count());
            Assert.Equal(lotsDTO[0].ClientItemId, result[0].ClientItemId);
            Assert.Equal(lotsDTO[0].Price, result[0].Price);
            Assert.Equal(lotsDTO[0].SellerClientId, result[0].SellerClientId);
            Assert.Equal(lotsDTO[1].ClientItemId, result[1].ClientItemId);
            Assert.Equal(lotsDTO[1].Price, result[1].Price);
            Assert.Equal(lotsDTO[1].SellerClientId, result[1].SellerClientId);
        }

        [Fact]
        public async Task GetLotsByClientIdAsync_ClientDontHaveLots()
        {
            //Arrange
            int clientId = 1;
            string exceptionMsg = "Client dont have lots";

            List<Lot> emptyLots = new List<Lot>();

            _lotRepository.Setup(x => x.GetLotsByClientIdAsync(clientId)).Returns(Task.FromResult(emptyLots));

            //Assert
            var result = await Assert.ThrowsAsync<Exception>(async () => await _lotService.GetLotsByClientIdAsync(clientId));

            Assert.Equal(exceptionMsg, result.Message);
        }

        #endregion

        #region RemoveLotByIdAsync
        [Fact]
        public async Task RemoveLotByIdAsync_Success()
        {
            //Arrange
            int lotId = 1;

            _lotRepository.Setup(x => x.RemoveLotByIdAsync(lotId)).Returns(Task.FromResult(true));

            //Act
            bool result = await _lotService.RemoveLotByIdAsync(lotId);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task RemoveLotByIdAsync_Failed()
        {
            //Arrange
            int lotId = 1;
            string exceptionMsg = "Faild to remove";

            _lotRepository.Setup(x => x.RemoveLotByIdAsync(lotId)).Returns(Task.FromResult(false));

            //Assert
            var result = await Assert.ThrowsAsync<Exception>(async () => await _lotService.RemoveLotByIdAsync(lotId));

            Assert.Equal(exceptionMsg, result.Message);
        }
        #endregion

        #region RemoveAllLotsByClientIdAsync
        [Fact]
        public async Task RemoveAllLotsByClientIdAsync_Success()
        {
            //Arrange
            int clientId = 1;

            _lotRepository.Setup(x => x.RemoveAllLotsByClientIdAsync(clientId)).Returns(Task.FromResult(true));

            //Act
            var result = await _lotService.RemoveAllLotsByClientIdAsync(clientId);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task RemoveAllLotsByClientIdAsync_Failed()
        {
            //Arrange
            int clientId = 1;
            string exceptionMsg = "Failed to remove";

            _lotRepository.Setup(x => x.RemoveAllLotsByClientIdAsync(clientId)).Returns(Task.FromResult(false));

            //Assert
            var result = await Assert.ThrowsAsync<Exception>(async () => await _lotService.RemoveAllLotsByClientIdAsync(clientId));

            Assert.Equal(exceptionMsg, result.Message);
        }
        #endregion
    }
}
