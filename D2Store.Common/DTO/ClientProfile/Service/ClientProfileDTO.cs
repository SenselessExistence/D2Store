﻿namespace D2Store.Common.DTO.ClientProfile.Service
{
    public class ClientProfileDTO : BaseEntityDTO
    {
        public int ClientId { get; set; }

        public DateTime Birthday { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string PhoneNumber { get; set; }

        public string About { get; set; }
    }
}
