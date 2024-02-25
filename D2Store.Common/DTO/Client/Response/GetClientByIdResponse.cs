using D2Store.Common.DTO.ClientProfile.Service;

namespace D2Store.Common.DTO.Client.Response
{
    public class GetClientByIdResponse
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public ClientProfileDTO Profile { get; set; }
    }
}
