namespace BackgroundJobs.Abstract
{
    public interface IMailService
    {
        void PasswordService(string to, string content);
    }
}
