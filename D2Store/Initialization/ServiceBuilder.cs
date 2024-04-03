using AutoMapper;
using D2Store.AutoMapperProfiles;
using D2Store.Business.Services;
using D2Store.Business.Services.Interfaces;
using D2Store.DAL;
using D2Store.DAL.AppInitializer;
using D2Store.DAL.Repository;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace D2Store.Initialization
{
    public static class ServiceBuilder
    {
        public static void BuildServices(IServiceCollection services)
        {
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<RoleManager<ApplicationRole>>();

            services.AddScoped<AppInitializer>();
            services.AddScoped<DataContext>();

            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IAuthorizationService, AuthorizationService>();

            services.AddScoped<IClientProfileRepository, ClientProfileRepository>();
            services.AddScoped<IClientProfileService, ClientProfileServices>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IRequestedItemRepository, RequestItemRepository>();
            services.AddScoped<IRequestedItemService, RequestedItemService>();

            services.AddScoped<ILotRepository, LotRepository>();
            services.AddScoped<ILotService, LotService>();

            services.AddScoped<ICartLotRepository, CartLotRepository>();
            services.AddScoped<ICartLotService, CartLotService>();

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();

            services.AddScoped<IHeroRepositoty, HeroRepository>();
            services.AddScoped<IHeroService, HeroService>();

            services.AddScoped<IClientItemRepository, ClientItemRepository>();
            services.AddScoped<IClientItemService, ClientItemService>();
        }

        public static IMapper BuildMapper()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClientMapperProfile());
                mc.AddProfile(new ClientProfileMapperProfile());
            });

            return mapperConfig.CreateMapper();
        }
    }
}
