using D2Store.Domain.Entities.Items;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2Store.DAL.EntityConfigurations
{
    public class RequestItemConfiguration : EntityConfigurations<RequestedItem>
    {
        public override void Configure(EntityTypeBuilder<RequestedItem> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
        }
    }
}
