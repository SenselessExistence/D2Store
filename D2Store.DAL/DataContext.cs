using D2Store.Domain.Entities;
using D2Store.Domain.Entities.Lots;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace D2Store.DAL
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public virtual DbSet<CompleteMigration> CompleteMigrations {  get; set; }

        public virtual DbSet<Lot> Lots { get; set; }

        public virtual DbSet<ClientProfile> UserProfiles { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Hero> Heroes { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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
