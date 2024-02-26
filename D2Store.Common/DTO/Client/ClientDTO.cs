using D2Store.Common.DTO.Cart;
using D2Store.Common.DTO.ClientProfile.Service;

namespace D2Store.Common.DTO.Client
{
    public class ClientDTO : BaseEntityDTO
    {
        public int UserId { get; set; }

        public ClientProfileDTO Profile { get; set; }

        public CartDTO Cart { get; set; }
    }
}
