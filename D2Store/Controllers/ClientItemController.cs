using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D2Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientItemController : ControllerBase
    {
        private readonly IClientItemService _clientItemService;

        public ClientItemController(IClientItemService clientItemService)
        {
            _clientItemService = clientItemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddClientItemAsync([FromBody]ClientItemDTO clientItemDTO)
        {
            var result = await _clientItemService.AddClientItemAsync(clientItemDTO);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateClientItemAsync([FromBody]ClientItemDTO clientItemDTO)
        {
            var result = await _clientItemService.UpdateClientItemAsync(clientItemDTO);

            return Ok(result);
        }

        [HttpGet]
        [Route("get/{clientItemId}")]
        public async Task<IActionResult> GetClientItemByIdAsync(int clientItemId)
        {
            var result = await _clientItemService.GetClientItemByIdAsync(clientItemId);

            return Ok(result);
        }

        [HttpGet]
        [Route("client/{clientId}")]
        public async Task<IActionResult> GetAllClientItemsByClientIdAsync(int clientId)
        {
            var result = await _clientItemService.GetAllClientItemsByClientIdAsync(clientId);

            return Ok(result);
        }

        [HttpDelete]
        [Route("remove/{clientItemId}")]
        public async Task<IActionResult> RemoveClientItemByIdAsync(int clientItemId)
        {
            await _clientItemService.RemoveClientItemByIdAsync(clientItemId);

            return Ok();
        }
    }
}
