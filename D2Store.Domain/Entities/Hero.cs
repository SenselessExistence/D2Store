using D2Store.Domain.Entities.Items;

namespace D2Store.Domain.Entities
{
    public class Hero : BaseEntity
    {
        public string HeroName { get; set; }

        public List<Item> Items { get; set; }
    }
}
