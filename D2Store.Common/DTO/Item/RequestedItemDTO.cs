namespace D2Store.Common.DTO.Item
{
    public class RequestedItemDTO : ItemDTO
    {
        public int ItemId { get; set; }

        public int ClientId { get; set; }

        public double ExpectedPrice { get; set; }
    }
}
