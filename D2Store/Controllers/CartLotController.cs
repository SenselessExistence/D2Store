using AutoMapper;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Cart;
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
        public async Task<IActionResult> AddLotCartLot(CartLotDTO lotToAdd)
        {
            await _cartLotService.AddLotToCartAsync(lotToAdd);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCartLotsByClientId(int clientId)
        {
            var result = await _cartLotService.GetAllCartLotsByClientIdAsync(clientId);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveLotFromCart(int lotId)
        {
            await _cartLotService.RemoveLotFromCartByIdAsync(lotId);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAllLotsFromCartByClientId(int clientId)
        {
            await _cartLotService.RemoveAllLotsFromCartByClientIdAsync(clientId);

            return Ok();
        }
    }
}