using D2Store.Common.DTO.Cart;
using D2Store.Common.DTO.ClientProfile;
using D2Store.Domain.Entities.Lots;

namespace D2Store.Common.DTO.Client
{
    public class ClientDTO
    {
        public int ClientProfileId { get; set; }

        public double Balance { get; set; }
    }
}
