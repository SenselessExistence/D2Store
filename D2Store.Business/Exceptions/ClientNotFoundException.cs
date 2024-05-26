namespace D2Store.Business.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(string message) : base(message) { }
    }
}
