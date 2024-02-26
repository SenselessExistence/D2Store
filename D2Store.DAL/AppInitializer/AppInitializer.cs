using D2Store.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace D2Store.DAL.AppInitializer
{
    public class AppInitializer
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly DataContext _dataContext;

        public AppInitializer(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            DataContext dataContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dataContext = dataContext;
        }

        public async Task InitializeDefaultData()
        {
            string completeMigrationId = "AD18BAF7-A489-443B-B542-68BE9BC936EE";
            if (!await _dataContext.CompleteMigrations.AnyAsync(m => m.CompleteMigrationId == completeMigrationId))
            {
                var identityResult = await CreateRolesAsync();

                if(identityResult.Succeeded)
                {
                    await CreateDefaultAdminAsync();
                }

                _dataContext.CompleteMigrations.Add(new CompleteMigration { CompleteMigrationId = completeMigrationId });

                await _dataContext.SaveChangesAsync();
            }

        }

        private async Task<IdentityResult> CreateRolesAsync()
        {
            List<ApplicationRole> roles = new List<ApplicationRole>()
            {
                new ApplicationRole {Name = "Admin", NormalizedName = "ADMINISTRATOR"},
                new ApplicationRole {Name = "Moder", NormalizedName = "MODERATOR"},
                new ApplicationRole {Name = "User", NormalizedName = "USER"}
            };

            IdentityResult identityResult = null;

            foreach (ApplicationRole role in roles)
            {
                identityResult = await _roleManager.CreateAsync(role);
            }

            return identityResult;
        }

        private async Task<IdentityResult> CreateDefaultAdminAsync()
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = "Admin",
                Email = "admin@gmail.com",
                PhoneNumber = "380374173056"
            };

            IdentityResult result = await _userManager.CreateAsync(user, "32184002gb");

            if(result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, "Admin");
            }
            return result;
        }
    }
}
