namespace D2Store.Domain.Entities.Items
{
    public class RequestedItem : BaseEntity
    {
        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public double ExpectedPrice { get; set; }
    }
}
