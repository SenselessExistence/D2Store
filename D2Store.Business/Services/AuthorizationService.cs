using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Authentication;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace D2Store.Business.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IClientRepository _clientRepository;
        private readonly IClientProfileRepository _clientProfileRepository;
        private readonly IConfiguration _configuration;

        private readonly string DefaultRole = "User";

        public AuthorizationService(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IClientRepository clientRepository,
            IClientProfileRepository clientProfileRepository,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _clientRepository = clientRepository;
            _clientProfileRepository = clientProfileRepository;
            _configuration = configuration;
        }

        public async Task<bool> Register(RegisterModel registerClient)
        {
            var clientExist = await _userManager.FindByEmailAsync(registerClient.Email);

            if (clientExist != null)
            {
                throw new Exception("User with that Email already exist");
            }

            ApplicationUser user = new()
            {
                Email = registerClient.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerClient.Username
            };

            var result = await _userManager.CreateAsync(user,registerClient.Password);

            if (!result.Succeeded)
            {
                throw new Exception("Something wrong to create a User.");
            }

            if (await _roleManager.RoleExistsAsync(DefaultRole))
            {
                await _userManager.AddToRoleAsync(user, DefaultRole);
            }
            else
            {
                throw new Exception("This role doesn`t exists.");

            }

            
            //Нужно доработать
            var client = await _clientRepository.AddClientAsync(new Client() { UserId = user.Id});

            await InitializeClientData(client.Id);

            return true;

        }

        public async Task<AuthorizationToken> Login(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if(user is null)
            {
                throw new Exception("User is not exist");
            }

            if(await _userManager.CheckPasswordAsync(user, loginModel.Password))
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

                return new AuthorizationToken
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationDate = token.ValidTo.Subtract(DateTime.MinValue).TotalSeconds
                };
            }

            return null;
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private async Task InitializeClientData(int id)
        {
            var profile = new ClientProfile
            {
                ClientId = id,
                FirstName = $"User{id}"
            };

            await _clientProfileRepository.CreateProfileAsync(profile);
        }
    }
}
