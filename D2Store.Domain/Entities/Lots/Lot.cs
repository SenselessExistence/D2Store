namespace D2Store.Domain.Entities.Lots
{
    public class Lot : BaseEntity
    {
        public int OwnerId { get; set; }

        public int ItemId { get; set; }

        public int CustomerId { get; set; }
    }
}
