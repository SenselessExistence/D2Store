using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;

namespace D2Store.DAL.Repository
{
    public class HeroRepository : BaseRepository<Hero>, IHeroRepositoty
    {
        public HeroRepository(DataContext context)
            :base(context)
        {
            
        }

        public async Task<Hero> AddHeroAsync(Hero heroToAdd)
        {
            return await AddAsync(heroToAdd);
        }

        public async Task<Hero> UpdateHeroByIdAsync(Hero heroToUpdate)
        {
            return await UpdateAsync(heroToUpdate);
        }

        public async Task<Hero> GetHeroByIdAsync(int heroId)
        {
            return await GetByIdAsync(heroId);
        }

        public async Task<bool> RemoveHeroByIdAsync(int heroId)
        {
            return await RemoveByIdAsync(heroId);
        }
    }
}
