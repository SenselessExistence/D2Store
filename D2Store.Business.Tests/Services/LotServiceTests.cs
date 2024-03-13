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
        private readonly LotService _lotService;

        public LotServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _lotRepository = new Mock<ILotRepository>();
            _lotService = new LotService(_lotRepository.Object, _mapper.Object);
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
                Id = lot.Id,
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
            Assert.Equal(lotDTO.Id, result.Id);
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
    }
}
