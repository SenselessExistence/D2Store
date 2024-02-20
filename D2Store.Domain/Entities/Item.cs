using D2Store.Domain.Enumerables;

namespace D2Store.Domain.Entities
{
    public class Item : BaseEntity
    {
        public string ItemName { get; set; }

        public string Description { get; set; }

        public Rarity Rarity { get; set; }

        public double Price { get; set; }

        public int GameId { get; set; }
    }
}
