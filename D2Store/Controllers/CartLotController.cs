using AutoMapper;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Lot;
using D2Store.Domain.Entities.Lots;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.JavaScript;

namespace D2Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartLotController : ControllerBase
    {
        private readonly ICartLotService _cartLotService;

        public CartLotController(ICartLotService cartLotService)
        {
            _cartLotService = cartLotService;
        }

        [HttpPost]
        [Route("Add lot to cart")]
        public async Task<IActionResult> AddLot(LotDTO lot, int clientId)
        {
            await _cartLotService.AddLotToCartAsync(lot, clientId);

            return Ok();
        }

        [HttpGet]
        [Route("Get cartLots")]
        public async Task<ActionResult<List<CartLot>>> GetCartLotsByClientId(int clientId)
        {
            var result = await _cartLotService.GetAllCartLotsByClientIdAsync(clientId);

            return Ok(result);
        }

        [HttpDelete]
        [Route("Remove lot from cartLots")]
        public async Task<IActionResult> RemoveLotFromCart(int lotId)
        {
            await _cartLotService.RemoveLotFromCartByIdAsync(lotId);

            return Ok();
        }

        [HttpDelete]
        [Route("Remove all lots from cartLots")]
        public async Task<IActionResult> RemoveAllLotsFromCartByClientId(int clientId)
        {
            await _cartLotService.RemoveAllLotsFromCartByClientIdAsync(clientId);

            return Ok();
        }
    }
}
