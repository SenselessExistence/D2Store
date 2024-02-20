namespace D2Store.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Email { get; set; }

        public string PhoneNumber {  get; set; }

        public string Password { get; set; }

        public double Balance { get; set; }
    }
}
