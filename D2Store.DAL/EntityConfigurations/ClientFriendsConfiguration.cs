using D2Store.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace D2Store.DAL.EntityConfigurations
{
    public class ClientFriendsConfiguration : EntityConfigurations<ClientFriends>
    {
        public override void Configure(EntityTypeBuilder<ClientFriends> builder)
        {
            base.Configure(builder);
        }
    }
}
