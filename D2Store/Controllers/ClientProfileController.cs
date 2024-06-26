﻿using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.ClientProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D2Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientProfileController : ControllerBase
    {
        private readonly IClientProfileService _clientProfileService;

        public ClientProfileController(IClientProfileService clientProfileService)
        {
            _clientProfileService = clientProfileService;
        }

        [HttpPost]
        public async Task<IActionResult> AddClientProfileAsync([FromBody] ClientProfileDTO clientProfileDTO)
        {
            var profile = await _clientProfileService.AddClientProfileAsync(clientProfileDTO);

            return Ok(profile);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateClientProfileAsync([FromBody] ClientProfileDTO clientProfileDTO)
        {
            var updatedProfile = await _clientProfileService.UpdateClientProfileAsync(clientProfileDTO);

            return Ok(updatedProfile);
        }

        [HttpGet]
        [Route("{clientProfileId}")]
        public async Task<IActionResult> GetClientProfileById(int clientProfileId)
        {
            var profile = await _clientProfileService.GetClientProfileByIdAsync(clientProfileId);

            return Ok(profile);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveClientProfileById(int clientProfileId)
        {
            await _clientProfileService.RemoveClientProfileByIdAsync(clientProfileId);

            return Ok();
        }
    }
}
