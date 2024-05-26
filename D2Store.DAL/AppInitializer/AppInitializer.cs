using D2Store.Domain.Entities;
using D2Store.Domain.Entities.Identity;
using D2Store.Domain.Entities.Items;
using D2Store.Domain.Entities.Lots;
using D2Store.Domain.Enumerables;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task InitializeDefaultDataAsync()
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

                await CreateDefaultUsersAsync();
                await CreateDefaultClientsAsync();
                await CreateDefaultHeroesAsync();
                await CreateDefaultItemsAsync();
                await CreateDefaultClientItemsAsync();

                await _dataContext.SaveChangesAsync();
            }
        }

        #region Private methods
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

        private async Task CreateDefaultHeroesAsync()
        {
            List<Hero> heroes = new List<Hero>()
            {
                new Hero
                {
                    HeroName = "Abaddon"
                },

                new Hero
                {
                    HeroName = "Alchemist"
                },

                new Hero
                {
                    HeroName = "Ancient Apparation"
                },

                new Hero
                {
                    HeroName = "Anti-Mage"
                },

                new Hero
                {
                    HeroName = "Arc Warden"
                }
            };

            await _dataContext.Heroes.AddRangeAsync(heroes);

            await _dataContext.SaveChangesAsync();
        }

        private async Task CreateDefaultItemsAsync()
        {
            List<Item> items = new List<Item>
            {
                new Item
                {
                    HeroId = 1,
                    ItemName = "Abaddon Horse",
                    Rarity = Rarity.Rare,
                    Description = "test description",
                    PictureURL = "testURL"
                },
                new Item
                {
                    HeroId = 2,
                    ItemName = "Alchemist midas",
                    Rarity = Rarity.Mythical,
                    Description = "test description",
                    PictureURL = "testURL"
                },
                new Item
                {
                    HeroId = 3,
                    ItemName = "Ancient Apparation head",
                    Rarity = Rarity.Legendary,
                    Description = "test description",
                    PictureURL = "testURL"
                },
                new Item
                {
                    HeroId = 4,
                    ItemName = "Manta Style weapon",
                    Rarity = Rarity.Legendary,
                    Description = "test description",
                    PictureURL = "testURL"
                },
                new Item
                {
                    HeroId = 5,
                    ItemName = "Spark",
                    Rarity = Rarity.Mythical,
                    Description = "test description",
                    PictureURL = "testURL"
                }
            };

            await _dataContext.Items.AddRangeAsync(items);

            await _dataContext.SaveChangesAsync();
        }

        private async Task CreateDefaultUsersAsync()
        {
            List<ApplicationUser> users = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    UserName = "Chad",
                    Email = "chad@gmail.com",
                    PhoneNumber = "390734162312"
                },
                new ApplicationUser
                {
                    UserName = "Kassel",
                    Email = "kassel.tinker@gmail.com",
                    PhoneNumber = "380934651285"
                },
                new ApplicationUser
                {
                    UserName = "Lens",
                    Email = "lens.doto@gmail.com",
                    PhoneNumber = "389652384326"
                },
                new ApplicationUser
                {
                    UserName = "Noname",
                    Email = "nonamedoto@gmail.com",
                    PhoneNumber = "380734454512"
                }
            };
         
            foreach (var user in users)
            {
                await _userManager.CreateAsync(user, "32184002Gb");

                await _userManager.AddToRoleAsync(user, "User");
            }
        }

        private async Task CreateDefaultClientsAsync()
        {
            List<Client> clients = new List<Client>
            {
                new Client
                {
                    UserId = 2,
                    Balance = 2000,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Client
                {
                    UserId = 3,
                    Balance = 1350,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Client
                {
                    UserId = 4,
                    Balance = 1590,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Client
                {
                    UserId = 5,
                    Balance = 10000,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                }
            };

            await _dataContext.Clients.AddRangeAsync(clients);
            
            await _dataContext.SaveChangesAsync();
        }

        private async Task CreateDefaultClientItemsAsync()
        {
            List<ClientItem> clientItems = new List<ClientItem>();

            for (int i = 0; i < 15; i++)
            {
                clientItems.Add(new ClientItem
                                {
                                    ClientId = new Random().Next(2, 5),
                                    ItemId = new Random().Next(1, 5),
                                    CreatedDate = DateTime.UtcNow
                                });
            }

            await _dataContext.ClientItems.AddRangeAsync(clientItems);
            await _dataContext.SaveChangesAsync();
        }
        #endregion
    }
}
