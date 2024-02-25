namespace D2Store.Common.DTO
{
    public class BaseEntityDTO
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
