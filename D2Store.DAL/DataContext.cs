using D2Store.DAL.EntityConfigurations;
using D2Store.Domain.Entities;
using D2Store.Domain.Entities.Identity;
using D2Store.Domain.Entities.Items;
using D2Store.Domain.Entities.Lots;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Emit;

namespace D2Store.DAL
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public virtual DbSet<CompleteMigration> CompleteMigrations {  get; set; }

        public virtual DbSet<Lot> Lots { get; set; }

        public virtual DbSet<CartLot> CartLots { get; set; }

        public virtual DbSet<ClientProfile> ClientProfiles { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<RequestedItem> RequestItems { get; set; }

        public virtual DbSet<ClientItem> ClientItems { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<ClientFriends> ClientFriends { get; set; }

        public virtual DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var assembly = typeof(ClientConfiguration).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembly);
        }

        public async Task<int> Initialize()
        {
            int updatedRowsCount = 0;
            List<CompleteMigration> completeMigrations = await this.CompleteMigrations.ToListAsync();

            using (var dbContextTransaction = await this.BeginTransactionAsync())
                try
                {
                    dbContextTransaction.Commit();
                    return updatedRowsCount;
                }
                catch
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
        }

        public virtual async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
