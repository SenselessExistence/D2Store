using D2Store.Domain.Entities;

namespace D2Store.DAL.Repository.Interfaces
{
    public interface IHeroRepositoty
    {
        Task<Hero> AddHeroAsync(Hero heroToAdd);

        Task<Hero> UpdateHeroByIdAsync(Hero heroToUpdate);

        Task<Hero> GetHeroByIdAsync(int heroId);

        Task<bool> RemoveHeroByIdAsync(int heroId);
    }
}
