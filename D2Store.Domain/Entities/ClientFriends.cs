namespace D2Store.Domain.Entities
{
    public class ClientFriends : BaseEntity
    {
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int FriendId { get; set; }

        public Client Friend { get; set; }
    }
}
