namespace D2Store.Domain.Entities
{
    public class Client : BaseEntity
    {
        public int UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ClientProfile Profile { get; set; }

        public Cart Cart { get; set; }

    }
}
