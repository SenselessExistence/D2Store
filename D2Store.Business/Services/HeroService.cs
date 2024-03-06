using AutoMapper;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Hero;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;

namespace D2Store.Business.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepositoty _heroRepository;
        private readonly IMapper _mapper;

        public HeroService(IHeroRepositoty heroRepositoty,
            IMapper mapper)
        {
            _heroRepository = heroRepositoty;
            _mapper = mapper;
        }

        public async Task<HeroDTO> AddHeroAsync(HeroDTO heroDTO)
        {
            var heroToAdd = _mapper.Map<Hero>(heroDTO);

            var createdHero = await _heroRepository.AddHeroAsync(heroToAdd);

            var result = _mapper.Map<HeroDTO>(createdHero);

            return result;
        }

        public async Task<HeroDTO> UpdateHeroAsync(HeroDTO heroDTO)
        {
            var heroToUpdate = _mapper.Map<Hero>(heroDTO);

            var updatedHero = await _heroRepository.UpdateHeroByIdAsync(heroToUpdate);

            var result = _mapper.Map<HeroDTO>(updatedHero);

            return result;
        }

        public async Task<HeroDTO> GetHeroByIdAsync(int heroId)
        {
            var hero = await _heroRepository.GetHeroByIdAsync(heroId);

            var result = _mapper.Map<HeroDTO>(hero);

            return result;
        }

        public async Task<bool> RemoveHeroByIdAsync(int heroId)
        {
            return await _heroRepository.RemoveHeroByIdAsync(heroId);
        }
    }
}
