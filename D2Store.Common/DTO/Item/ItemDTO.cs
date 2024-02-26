using D2Store.Domain.Enumerables;

namespace D2Store.Common.DTO.Item
{
    public class ItemDTO : BaseEntityDTO
    {
        public int HeroId { get; set; }

        public string ItemName { get; set; }

        public string Description { get; set; }

        public Rarity Rarity { get; set; }
    }
}
