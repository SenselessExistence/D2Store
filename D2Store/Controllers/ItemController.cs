using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D2Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddItemAsync([FromBody]ItemDTO itemDTO)
        {
            await _itemService.AddItemAsync(itemDTO);

            return Ok(itemDTO);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateItemAsync([FromBody]ItemDTO itemDTO)
        {
            await _itemService.UpdateItemAsync(itemDTO);

            return Ok(itemDTO);
        }

        [HttpGet]
        [Route("{itemId}")]
        public async Task<IActionResult> GetItemByIdAsync(int itemId)
        {
            var item = await _itemService.GetItemByIdAsync(itemId);

            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveItemById(int itemId)
        {
            await _itemService.RemoveItemByIdAsync(itemId);

            return Ok();
        }
    }
}
