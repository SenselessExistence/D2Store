using D2Store.Common.DTO.Hero;

namespace D2Store.Business.Services.Interfaces
{
    public interface IHeroService
    {
        Task<HeroDTO> AddHeroAsync(HeroDTO heroDTO);

        Task<HeroDTO> UpdateHeroAsync(HeroDTO heroDTO);

        Task<HeroDTO> GetHeroByIdAsync(int heroId);

        Task<List<HeroDTO>> GetHeroesByNameAsync(string heroName);

        Task<bool> RemoveHeroByIdAsync(int heroId);
    }
}
