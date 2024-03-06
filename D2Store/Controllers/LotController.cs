using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Lot;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D2Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LotController : ControllerBase
    {
        private readonly ILotService _lotService;

        public LotController(ILotService lotService)
        {
            _lotService = lotService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLotAsync([FromBody]LotDTO lotDTO)
        {
            await _lotService.AddLotAsync(lotDTO);

            return Ok();
        }

        [HttpPatch]
        [Route("Update")]
        public async Task<IActionResult> UpdateLotAsync([FromBody]LotDTO lotDTO)
        {
            await _lotService.UpdateLotAsync(lotDTO);

            return Ok();
        }

        [HttpGet]
        [Route("{clientId}")]
        public async Task<IActionResult> GetLotsByClientIdAsync(int clientId)
        {
            var result = await _lotService.GetLotsByClientIdAsync(clientId);

            return Ok(result);
        }

        [HttpGet]
        [Route("{lotId}")]
        public async Task<IActionResult> GetLotByIdAsync(int lotId)
        {
            var result = await _lotService.GetLotByIdAsync(lotId);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{lotId}")]
        public async Task<IActionResult> RemoveLotById(int lotId)
        {
            await _lotService.RemoveLotByIdAsync(lotId);

            return Ok();
        }

        [HttpDelete]
        [Route("{clientId}")]
        public async Task<IActionResult> RemoveAllLotsByClientId(int clientId)
        {
            await _lotService.RemoveAllLotsByClientId(clientId);

            return Ok();
        }
    }
}
