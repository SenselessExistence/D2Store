namespace D2Store.Domain.Entities.Lots
{
    public class LotItem : BaseEntity
    {
        public int ItemId { get; set; }

        public int LotId { get; set; }

        public int OwnerId { get; set; }
    }
}
