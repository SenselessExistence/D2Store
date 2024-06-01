using AutoMapper;
using D2Store.Business.Exceptions;
using D2Store.Business.Services.Interfaces;
using D2Store.Common.DTO.Hero;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;

namespace D2Store.Business.Services
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepositoty _heroRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<HeroService> _logger;

        public HeroService(IHeroRepositoty heroRepositoty,
            IMapper mapper,
            ILogger<HeroService> logger)
        {
            _heroRepository = heroRepositoty;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<HeroDTO> AddHeroAsync(HeroDTO heroDTO)
        {
            if (heroDTO.HeroName.Length == 0)
            {
                throw new ArgumentException("Invalid hero name!");
            }

            var heroToAdd = _mapper.Map<Hero>(heroDTO);

            var createdHero = await _heroRepository.AddHeroAsync(heroToAdd);

            var result = _mapper.Map<HeroDTO>(createdHero);

            return result;
        }

        public async Task<HeroDTO> UpdateHeroAsync(HeroDTO heroDTO)
        {
            if (heroDTO.HeroName.Length == 0)
            {
                throw new ArgumentException("Invalid hero name!");
            }

            var heroToUpdate = _mapper.Map<Hero>(heroDTO);

            var updatedHero = await _heroRepository.UpdateHeroByIdAsync(heroToUpdate);

            var result = _mapper.Map<HeroDTO>(updatedHero);

            return result;
        }

        public async Task<HeroDTO> GetHeroByIdAsync(int heroId)
        {
            var hero = await _heroRepository.GetHeroByIdAsync(heroId);

            hero.ThrowIfNull("hero", _logger, $"Hero with ID: {heroId} does not exist!");

            var result = _mapper.Map<HeroDTO>(hero);

            return result;
        }

        public async Task<List<HeroDTO>> GetHeroesByNameAsync(string heroName)
        {
            var listHeroes = await _heroRepository.GetHeroesByNameAsync(heroName);

            if (listHeroes.Count == 0)
            {
                throw new BadHttpRequestException("Heroes not found");
            }

            var result = _mapper.Map<List<HeroDTO>>(listHeroes);

            return result;
        }

        public async Task<bool> RemoveHeroByIdAsync(int heroId)
        {
            if (heroId == 0)
            {
                throw new ArgumentException("Invalid hero ID!");
            }

            return await _heroRepository.RemoveHeroByIdAsync(heroId);
        }
    }
}
