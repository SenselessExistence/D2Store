﻿namespace D2Store.Common.DTO.ClientProfile.ClientProfileResponse
{
    public class GetClientProfileResponse
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string About { get; set; }
    }
}