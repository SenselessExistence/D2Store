using D2Store.Domain.Entities.Items;

namespace D2Store.Common.DTO.Lot
{
    public class LotDTO
    {
        public int ClientItemId { get; set; }

        public int SellerClientId { get; set; }

        public double Price { get; set; }

    }
}
