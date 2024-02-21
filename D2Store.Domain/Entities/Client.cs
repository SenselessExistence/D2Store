namespace D2Store.Domain.Entities
{
    public class Client : BaseEntity
    {
        public int UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber {  get; set; }

        public int ProfileId { get; set; }

        public double Balance { get; set; }
    }
}
