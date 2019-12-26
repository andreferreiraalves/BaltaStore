namespace BaltaStore.Domain.StoreContext.Service
{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string body);
    }
}