using D2Store.Domain.Entities.Lots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2Store.DAL.EntityConfigurations
{
    public class CartLotConfiguration : EntityConfigurations<CartLot>
    {
        public override void Configure(EntityTypeBuilder<CartLot> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.HasOne(cl => cl.Lot)
                   .WithMany()
                   .HasForeignKey(cl => cl.LotId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
