using D2Store.DAL;
using D2Store.DAL.AppInitializer;
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
        }
    }
}
