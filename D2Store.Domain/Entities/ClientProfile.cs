﻿namespace D2Store.Domain.Entities
{
    public class ClientProfile : BaseEntity
    {
        public int ClientId { get; set; }
        
        public Client Client { get; set; }

        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string About { get; set; }
    }
}
