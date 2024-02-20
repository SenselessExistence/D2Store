namespace D2Store.Domain.Entities
{
    public class BaseEntity
    {
            public int Id { get; set; }

            public DateTime CreatedDate { get; set; }

            public DateTime UpdatedDate { get; set; }

            public bool IsActive { get; set; }
    }
}
