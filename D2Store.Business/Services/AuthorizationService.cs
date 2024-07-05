using AutoMapper;
using D2Store.Business.Exceptions;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Authentication;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;
using D2Store.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;
using System.Text;

namespace D2Store.Business.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IClientRepository _clientRepository;
        private readonly IClientProfileRepository _clientProfileRepository;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        private readonly string DefaultRole = "User";

        public AuthorizationService(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IClientRepository clientRepository,
            IClientProfileRepository clientProfileRepository,
            IConfiguration configuration,
            IEmailService emailService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _clientRepository = clientRepository;
            _clientProfileRepository = clientProfileRepository;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<bool> RegisterAsync(RegisterModel registerClient)
        {
            await CheckIsUserNotExistsAsync(registerClient.Email);

            var user = await CreateApplicationUserAsync(registerClient);

            await _userManager.AddToRoleAsync(user, DefaultRole);
            
            int clientId = await InitializeClientDataAsync(user.Id);

            await InitializeProfileData(registerClient.Nickname, clientId, user.Id);

            return true;
        }

        public async Task<AuthorizationToken> LoginAsync(LoginModel loginModel)
        {
            var user = await CheckIsUserExistAsync(loginModel.Email);

            return await CheckPasswordAsync(loginModel, user);
        }

        #region Private methods
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }

        private async Task<int> InitializeClientDataAsync(int userId)
        {
            var client = new Client()
            {
                UserId = userId
            };

            client = await _clientRepository.AddClientAsync(client);

            return client.Id;
        }
        
        private async Task<ClientProfile> InitializeProfileData(string nickname, int clientId, int userId)
        {
            var profile = new ClientProfile
            {
                Nickname = nickname,
                ClientId = clientId,
                FirstName = $"User{userId}"
            };

            return await _clientProfileRepository.CreateProfileAsync(profile);
        }
        
        private async Task<ApplicationUser> CheckIsUserNotExistsAsync(string email)
        {
            var clientExist = await _userManager.FindByEmailAsync(email);

            if (clientExist != null)
            {
                throw new VerificationException($"User with Email: {email} already exist!");
            }

            return clientExist;
        }
        
        private async Task<ApplicationUser> CheckIsUserExistAsync(string email)
        {
            var clientExist = await _userManager.FindByEmailAsync(email);

            if (clientExist == null)
            {
                throw new Exception($"User with Email: {email} is not exist!");
            }

            return clientExist;
        }
        
        private async Task<ApplicationUser> CreateApplicationUserAsync(RegisterModel registerClient)
        {
            ApplicationUser user = new()
            {
                Email = registerClient.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerClient.Nickname
            };

            var result = await _userManager.CreateAsync(user, registerClient.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    throw new Exception($"{item.Description}");
                }
            }

            return user;
        }
        
        private async Task<JwtSecurityToken> GetClaimsAsync(ApplicationUser? user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserId", user.Id.ToString())
                };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = GetToken(authClaims);
            return token;
        }
        
        private async Task<AuthorizationToken> CheckPasswordAsync(LoginModel loginModel, ApplicationUser user)
        {
            if (await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                JwtSecurityToken token = await GetClaimsAsync(user);

                return new AuthorizationToken
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationDate = token.ValidTo.Subtract(DateTime.MinValue).TotalDays
                };
            }
            else
            {
                throw new Exception("Invalid password!");
            }
        }
        #endregion
    }
}
