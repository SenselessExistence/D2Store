using D2Store.Domain.Entities.Items;

namespace D2Store.Domain.Entities.Lots
{
    public class Lot : BaseEntity
    {
        public int ClientItemId { get; set; }

        public ClientItem ClientItem { get; set; }

        public int SellerClientId { get; set; }

        public Client SellerClient { get; set; }

        public double Price { get; set; }

        public DateTime? SellDate { get; set; }
    }
}
