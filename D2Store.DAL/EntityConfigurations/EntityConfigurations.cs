using Castle.Core.Configuration;
using D2Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2Store.DAL.EntityConfigurations
{
    public abstract class EntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {

        }


    }
}
