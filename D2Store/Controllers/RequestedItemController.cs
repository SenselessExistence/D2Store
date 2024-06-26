﻿using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D2Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestedItemController : ControllerBase
    {
        private readonly IRequestedItemService _requestedItemService;

        public RequestedItemController(IRequestedItemService requestedItemService)
        {
            _requestedItemService = requestedItemService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRequestedItemAsync([FromBody]RequestedItemDTO requestedItemDTO)
        {
            var requestedItem = await _requestedItemService.AddRequestedItemAsync(requestedItemDTO);

            return Ok(requestedItem);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateRequestItemAsync([FromBody]RequestedItemDTO requestedItemDTO)
        {
            var updatedRequestedItem = await _requestedItemService.UpdateRequestedItemAsync(requestedItemDTO);

            return Ok(updatedRequestedItem);
        }

        [HttpGet]
        [Route("{requestItemId}")]
        public async Task<IActionResult> GetRequestedItemByIdAsync(int requestedItemId)
        {
            var requestedItem = await _requestedItemService.GetRequestedItemByIdAsync(requestedItemId);

            return Ok(requestedItem);
        }

        [HttpGet]
        [Route("{clientId}")]
        public async Task<IActionResult> GetRequestedItemsByClientIdAsync(int clientId)
        {
            var requestedItems = await _requestedItemService.GetRequestedItemsByClientIdAsync(clientId);

            return Ok(requestedItems);
        }

        [HttpDelete]
        [Route("{requestItemId}")]
        public async Task<IActionResult> RemoveRequestedItemByIdAsync(int requestedItemId)
        {
            await _requestedItemService.RemoveRequestedItemByIdAsync(requestedItemId);

            return Ok();
        }

        [HttpDelete]
        [Route("{clientId}")]
        public async Task<IActionResult> RemoveRequestedItemsByClientIdAsync(int clientId)
        {
            await _requestedItemService.RemoveRequestedItemsByClientIdAsync(clientId);

            return Ok();
        }
    }
}
