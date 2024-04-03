using D2Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2Store.DAL.EntityConfigurations
{
    public class ClientConfiguration : EntityConfigurations<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.HasOne(c => c.ApplicationUser)
                .WithOne()
                .HasForeignKey<Client>(c => c.UserId);

            builder.HasMany(c => c.CartLots)
                .WithOne(c => c.Client)
                .HasForeignKey(c => c.ClientId);

            builder.HasOne(c => c.ClientProfile)
                .WithOne()
                .HasForeignKey<Client>(c => c.ClientProfileId);

            builder.HasMany(c => c.ClientItems)
                .WithOne()
                .HasForeignKey(i => i.ClientId);

            builder
        }
    }
}
