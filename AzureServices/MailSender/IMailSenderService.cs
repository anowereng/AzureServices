namespace MailSender
{
    public interface IMailSenderService
    {
        Task<bool> SendAsync(string to, string subject, string content);
    }
}