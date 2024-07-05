using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D2Store.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> AddClientAsync(ClientDTO clientDTO)
        {
            var reuslt = await _clientService.AddClientAsync(clientDTO);

            return Ok(reuslt);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateClientAsync(ClientDTO clientDTO)
        {
            var result = await _clientService.UpdateClientAsync(clientDTO);

            return Ok(result);
        }

        [HttpGet]
        [Route("{clientId}")]
        public async Task<IActionResult> GetClientByIdAsync(int clientId)
        {
            var result = await _clientService.GetClientByIdAsync(clientId);

            return Ok(result);
        }

        [HttpDelete]
        [Route("clientId")]
        public async Task<IActionResult> RemoveClientByIdAsync(int clientId)
        {
            await _clientService.RemoveClientByIdAsync(clientId);

            return Ok();
        }
    }
}
