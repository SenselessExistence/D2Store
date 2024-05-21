using D2Store.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace D2Store.Domain.Entities
{
    public class ClientProfile : BaseEntity
    {
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public DateTime Birthday { get; set; }

        public string Nickname { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string About { get; set; }
    }
}
