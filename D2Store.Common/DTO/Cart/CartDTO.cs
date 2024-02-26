using D2Store.Common.DTO.Item;

namespace D2Store.Common.DTO.Cart
{
    public class CartDTO : BaseEntityDTO
    {
        public int ClientId { get; set; }

        public List<ItemDTO> Items { get; set; }
    }
}
