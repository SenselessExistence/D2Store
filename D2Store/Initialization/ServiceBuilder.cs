using AutoMapper;
using D2Store.AutoMapperProfiles;
using D2Store.Business.Services;
using D2Store.Business.Services.Interfaces;
using D2Store.DAL;
using D2Store.DAL.AppInitializer;
using D2Store.DAL.Repository;
using D2Store.DAL.Repository.Interfaces;
using D2Store.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace D2Store.Initialization
{
    public static class ServiceBuilder
    {
        public static void BuildServices(IServiceCollection services)
        {
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<RoleManager<IdentityRole>>();

            services.AddScoped<AppInitializer>();
            services.AddScoped<DataContext>();

            services.AddScoped<IAuthorizationService, AuthorizationService>();

            services.AddScoped<IClientProfileRepository, ClientProfileRepository>();
            services.AddScoped<IClientProfileService, ClientProfileServices>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();
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
