namespace D2Store.Business.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string clientName);
    }
}
