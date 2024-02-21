using D2Store.Domain.Enumerables;

namespace D2Store.Domain.Entities
{
    public class Item : BaseEntity
    {
        public int HeroId { get; set; }

        public string ItemName { get; set; }

        public string Description { get; set; }

        public Rarity Rarity { get; set; }


    }
}
