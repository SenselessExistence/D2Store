using D2Store.Domain.Entities.Items;
using D2Store.Domain.Entities.Lots;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Store.DAL.EntityConfigurations
{
    public class ItemConfiguration : EntityConfigurations<Item>
    {
        public override void Configure(EntityTypeBuilder<Item> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
        }
    }
}
