using D2Store.Domain.Entities.Lots;

namespace D2Store.Domain.Entities.Items
{
    public class ClientItem : BaseEntity
    {
        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public Lot Lot { get; set; }
    }
}
