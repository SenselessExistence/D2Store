namespace D2Store.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public int ClientId { get; set; }

        public List<Item>? Items { get; set; }
    }
}
