using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Hero;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace D2Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _heroService;

        public HeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpPost]
        public async Task<IActionResult> AddHeroAsync([FromBody]HeroDTO hero)
        {
            var result = await _heroService.AddHeroAsync(hero);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateHeroAsync([FromBody]HeroDTO hero)
        {
            var result = await _heroService.UpdateHeroAsync(hero);

            return Ok(result);
        }

        [HttpGet]
        [Route("{heroId}")]
        public async Task<IActionResult> GetHeroByIdAsync(int heroId)
        {
            var result = await _heroService.GetHeroByIdAsync(heroId);

            return Ok(result);
        }

        [HttpGet]
        [Route("name/{heroName}")]
        public async Task<IActionResult> GetHeroesByNameAsync(string heroName)
        {
            var result = await _heroService.GetHeroesByNameAsync(heroName);

            return Ok(result);
        }


        [HttpDelete]
        [Route("{removeHeroId}")]
        public async Task<IActionResult> RemoveHeroByIdAsync(int removeHeroId)
        {
            await _heroService.RemoveHeroByIdAsync(removeHeroId);

            return Ok();
        }
    }
}
