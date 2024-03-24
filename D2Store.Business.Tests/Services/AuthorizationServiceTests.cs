using D2Store.Business.Services;
using Microsoft.Extensions.Configuration;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Moq;
using D2Store.Common.DTO.Authentication;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace D2Store.Business.Tests.Services
{
    public class AuthorizationServiceTests
    {
        private readonly Mock<IUserStore<ApplicationUser>> _userStore;
        private readonly Mock<IRoleStore<ApplicationRole>> _roleStore;
        private readonly Mock<UserManager<ApplicationUser>> _userManager;
        private readonly Mock<RoleManager<ApplicationRole>> _roleManager;
        private readonly Mock<IClientRepository> _clientRepository;
        private readonly Mock<IClientProfileRepository> _profileRepository;
        private readonly IConfiguration _configuration;
        private readonly AuthorizationService _authorizationService;

        private readonly string DefaultRole = "User";

        public AuthorizationServiceTests()
        {
            _userStore = new Mock<IUserStore<ApplicationUser>>();
            _roleStore = new Mock<IRoleStore<ApplicationRole>>();
            _userManager = new Mock<UserManager<ApplicationUser>>(_userStore.Object, null, null, null, null, null, null, null, null);
            _roleManager = new Mock<RoleManager<ApplicationRole>>(_roleStore.Object, null, null, null, null);
            _clientRepository = new Mock<IClientRepository>();
            _profileRepository = new Mock<IClientProfileRepository>();
            _configuration = new ConfigurationBuilder().AddInMemoryCollection(GetConfig()).Build();
            _authorizationService = new AuthorizationService(_userManager.Object,
                _roleManager.Object,
                _clientRepository.Object,
                _profileRepository.Object,
                _configuration);
        }

        
        private Dictionary<string,string> GetConfig()
        {
            var myConfig = new Dictionary<string, string>()
            {
                {"Jwt:Secret", "my-32-character-ultra-secure-and-ultra-long-secret" },
                {"Jwt:ValidIssuer", "D2Store.com" },
                {"Jwt:ValidAudience", "D2StoreUser" }
            };

            return myConfig;
        }

        #region Register
        [Fact]
        public async Task Register_Success()
        {
            //Arrange
            RegisterModel register = new RegisterModel
            {
                Email = "testее.email@gmail.com",
                Nickname = "TestNickName",
                Password = "testPassword123"
            };

            ApplicationUser applicationUser = new ApplicationUser
            {
                Id = 1,
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Nickname,
                PasswordHash = "asdasd",
                AccessFailedCount = 0,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                NormalizedEmail = "normEmail",
                NormalizedUserName = "TEST",
                PhoneNumber = null,
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = false,
                LockoutEnd = null,
                PhoneNumberConfirmed = false
            };

            IdentityResult identityResult = IdentityResult.Success;

            _userManager.SetupSequence(x => x.FindByEmailAsync(register.Email))
                .Returns(Task.FromResult((ApplicationUser)null))
                .ReturnsAsync(applicationUser);
            _userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), register.Password)).ReturnsAsync(identityResult);
            _roleManager.Setup(x => x.RoleExistsAsync(DefaultRole)).Returns(Task.FromResult(true));
            _userManager.Setup(x => x.AddToRoleAsync(applicationUser, DefaultRole));

            //Act
            bool result = await _authorizationService.Register(register);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Register_UserExistError()
        {
            string exceptionMsg = "User with that Email already exist";

            RegisterModel registerModel = new RegisterModel
            {
                Email = "test@gmail.com",
                Nickname = "testNick",
                Password = "test123_"
            };

            ApplicationUser applicationUser = new ApplicationUser
            {

            };

            _userManager.Setup(x => x.FindByEmailAsync(registerModel.Email)).Returns(Task.FromResult(applicationUser));

            var result = await Assert.ThrowsAsync<Exception>(async () => await _authorizationService.Register(registerModel));

            Assert.Equal(exceptionMsg, result.Message);
        }

        [Fact]
        public async Task Register_FailedToRegisterError()
        {
            string exceptionMsg = "Failed to register.";

            RegisterModel register = new RegisterModel
            {
                Email = "testее.email@gmail.com",
                Nickname = "TestNickName",
                Password = "testPassword123"
            };


            ApplicationUser applicationUser = new ApplicationUser
            {
                Id = 1,
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Nickname,
                PasswordHash = "asdasd",
                AccessFailedCount = 0,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                NormalizedEmail = "normEmail",
                NormalizedUserName = "TEST",
                PhoneNumber = null,
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = false,
                LockoutEnd = null,
                PhoneNumberConfirmed = false
            };

            IdentityResult identityResult = IdentityResult.Failed();

            _userManager.Setup(x => x.FindByEmailAsync(register.Email)).Returns(Task.FromResult((ApplicationUser)null));
            _userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), register.Password)).ReturnsAsync(identityResult);

            var result = await Assert.ThrowsAsync<Exception>(async () => await _authorizationService.Register(register));

            Assert.Equal(exceptionMsg, result.Message);
        }

        [Fact]
        public async Task Register_RoleDoesntExistError()
        {
            string exceptionMsg = "This role doesn`t exists.";

            RegisterModel register = new RegisterModel
            {
                Email = "testее.email@gmail.com",
                Nickname = "TestNickName",
                Password = "testPassword123"
            };

            ApplicationUser applicationUser = new ApplicationUser
            {
                Id = 1,
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Nickname,
                PasswordHash = "asdasd",
                AccessFailedCount = 0,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                NormalizedEmail = "normEmail",
                NormalizedUserName = "TEST",
                PhoneNumber = null,
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                LockoutEnabled = false,
                LockoutEnd = null,
                PhoneNumberConfirmed = false
            };

            IdentityResult identityResult = IdentityResult.Success;

            _userManager.Setup(x => x.FindByEmailAsync(register.Email))
                .Returns(Task.FromResult((ApplicationUser)null));
            _userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), register.Password)).ReturnsAsync(identityResult);
            _roleManager.Setup(x => x.RoleExistsAsync(DefaultRole)).Returns(Task.FromResult(false));

            var result = await Assert.ThrowsAsync<Exception>(async () => await _authorizationService.Register(register));

            Assert.Equal(exceptionMsg, result.Message);
        }
        #endregion

        #region Login
        [Fact]
        public async Task Login_Success()
        {
            LoginModel loginModel = new LoginModel
            {
                Email = "test@email.com",
                Password = "testPassword123"
            };

            ApplicationUser user = new ApplicationUser
            {
                Id = 1,
                UserName = "TestUser",
                Email = loginModel.Email
            };

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", user.Id.ToString())
            };

            IList<string> userRoles = new List<string> { "User" };

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])), SecurityAlgorithms.HmacSha256)
            );

            // Act
            _userManager.Setup(x => x.FindByEmailAsync(loginModel.Email)).ReturnsAsync(user);
            _userManager.Setup(x => x.CheckPasswordAsync(user, loginModel.Password)).ReturnsAsync(true);
            _userManager.Setup(x => x.GetRolesAsync(user)).Returns(Task.FromResult(userRoles));
            var result = await _authorizationService.Login(loginModel);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Token);
            Assert.True(result.ExpirationDate > 0);
        }

        [Fact]
        public async Task Login_UserNotExistError()
        {
            string exceptionMsg = "User is not exist";

            LoginModel loginModel = new LoginModel
            {
                Email = "test@gmail.com",
                Password = "password"
            };

            _userManager.Setup(x => x.FindByEmailAsync(loginModel.Email)).Returns(Task.FromResult((ApplicationUser)null));

            var result = await Assert.ThrowsAsync<Exception>(async () => await _authorizationService.Login(loginModel));

            Assert.Equal(exceptionMsg, result.Message);
        }

        [Fact]
        public async Task Login_CheckPasswordError()
        {
            string exceptionMsg = "Invalid password!";

            LoginModel loginModel = new LoginModel()
            {
                Email = "test@gmail.com",
                Password = "password"
            };

            ApplicationUser user = new ApplicationUser() { };

            _userManager.Setup(x => x.FindByEmailAsync(loginModel.Email)).Returns(Task.FromResult(user));
            _userManager.Setup(x => x.CheckPasswordAsync(user, loginModel.Password)).Returns(Task.FromResult(false));

            var result = await Assert.ThrowsAsync<Exception>(async () => await _authorizationService.Login(loginModel));

            Assert.Equal(exceptionMsg, result.Message);
        }
        #endregion
    }
}
