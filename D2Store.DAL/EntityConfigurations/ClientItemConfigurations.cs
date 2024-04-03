using D2Store.Domain.Entities.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2Store.DAL.EntityConfigurations
{
    public class ClientItemConfigurations : EntityConfigurations<ClientItem>
    {
        public override void Configure(EntityTypeBuilder<ClientItem> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.HasOne(ci => ci.Client)
                   .WithMany(c => c.ClientItems)
                   .HasForeignKey(ci => ci.ClientId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
