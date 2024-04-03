using D2Store.Domain.Enumerables;
using System.ComponentModel.DataAnnotations.Schema;

namespace D2Store.Domain.Entities.Items
{
    public class Item : BaseEntity
    {
        public int HeroId { get; set; }

        public Hero Hero { get; set; }

        public string ItemName { get; set; }

        public string Description { get; set; }

        public Rarity Rarity { get; set; }

        public string PictureURL { get; set; }
    }
}
