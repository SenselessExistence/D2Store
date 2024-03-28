using D2Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2Store.DAL.EntityConfigurations
{
    public class ClientProfileConfiguration : EntityConfigurations<ClientProfile>
    {
        public override void Configure(EntityTypeBuilder<ClientProfile> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(c => c.About)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.Property(c => c.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasMaxLength(20)
                .IsRequired(false);

            builder.Property(c => c.Birthday)
                .IsRequired(false);

            builder.Property(c => c.PhoneNumber)
                .HasMaxLength(10)
                .IsRequired(false);

            builder.Property(c => c.Nickname)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasOne(c => c.Client)
                .WithOne()
                .HasForeignKey<ClientProfile>(c => c.ClientId);
        }
    }
}
