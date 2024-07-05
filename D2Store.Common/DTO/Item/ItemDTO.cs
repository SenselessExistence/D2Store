using D2Store.Domain.Enumerables;
using System.ComponentModel.DataAnnotations;

namespace D2Store.Common.DTO.Item
{
    public class ItemDTO
    {
        [Required]
        public int HeroId { get; set; }
        
        [Required]
        public string ItemName { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]

        public Rarity Rarity { get; set; }

        [Required]
        public string PictureURL { get; set; }
    }
}
