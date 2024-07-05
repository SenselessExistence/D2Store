using AutoMapper;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Authentication;
using D2Store.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IAuthorizationService = D2Store.Business.Services.Interfaces.IAuthorizationService;

namespace D2Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;


        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel registerModel)
        {
            var result = await _authorizationService.RegisterAsync(registerModel);

            return Ok(result);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            var result = await _authorizationService.LoginAsync(loginModel);

            return result == null ? Unauthorized() : Ok(result);
        }
    }
}
