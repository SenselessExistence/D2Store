using D2Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2Store.DAL.EntityConfigurations
{
    public class HeroConfiguration : EntityConfigurations<Hero>
    {
        public override void Configure(EntityTypeBuilder<Hero> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(c => c.HeroName)
                .IsRequired();
        }
    }
}
