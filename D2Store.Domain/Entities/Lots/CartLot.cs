namespace D2Store.Domain.Entities.Lots
{
    public class CartLot : BaseEntity
    {
        public int LotId { get; set; }

        public Lot Lot { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public double ExpectedPrice { get; set; }
    }
}
