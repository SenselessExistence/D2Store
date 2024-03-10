using D2Store.DAL;
using D2Store.DAL.Repository;
using D2Store.DAL.Tests.MockDbSet;
using D2Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace D2Store.DAL.Tests.Repositories
{
    public class ClientProfileRepositoryTests
    {
        private readonly Mock<DataContext> _context;
        private readonly ClientProfileRepository _repository;

        public ClientProfileRepositoryTests()
        {
            var mockOptions = new DbContextOptions<DataContext>();
            _context = new Mock<DataContext>(mockOptions);
            _repository = new ClientProfileRepository(_context.Object);
        }

        #region AddAsync
        [Fact]
        public async Task CreateProfileAsync_Success()
        {
            //Arrange
            var clientProfile = new ClientProfile
            {
                FirstName = "Ben",
                LastName = "Jobs",
                Nickname = "Steve",
                PhoneNumber = "3801223423",
                About = "Test description",
                ClientId = 1
            };

            var clientProfiles = new List<ClientProfile> { clientProfile };

            _context.Setup(x => x.Set<ClientProfile>()).Returns(clientProfiles.AsDbSetMock().Object);
            _context.Setup(x => x.AddAsync(clientProfile, default));
            _context.Setup(x => x.SaveChangesAsync(default)).Returns(Task.FromResult(1));


            //Act
            var result = await _repository.CreateProfileAsync(clientProfile);
            
            //Assert
            Assert.NotNull(result);
            Assert.Equal(clientProfile.Id, result.Id);
            Assert.Equal(clientProfile.FirstName, result.FirstName);
            Assert.Equal(clientProfile.LastName, result.LastName);
            Assert.Equal(clientProfile.About, result.About);
            Assert.Equal(clientProfile.PhoneNumber, result.PhoneNumber);
            Assert.Equal(clientProfile.ClientId, result.ClientId);
        }
        #endregion
    }
}
