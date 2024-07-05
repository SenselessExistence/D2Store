namespace D2Store.Common.DTO.ClientProfile
{
    public class ClientProfileDTO
    {
        public int ClientId { get; set; }

        public DateTime? Birthday { get; set; }

        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public string Nickname { get; set; }

        public string? PhoneNumber { get; set; }

        public string? About { get; set; }
    }
}
