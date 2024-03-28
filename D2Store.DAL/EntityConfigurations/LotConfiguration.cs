using D2Store.Domain.Entities.Lots;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2Store.DAL.EntityConfigurations
{
    public class LotConfiguration : EntityConfigurations<Lot>
    {
        public override void Configure(EntityTypeBuilder<Lot> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
        }
    }
}
