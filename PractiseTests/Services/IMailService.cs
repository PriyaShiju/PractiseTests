namespace PractiseTests.Services
{
    public interface IMailService
    {
        void SendMessage(string Name, string FromEmailAddress, string ToEmailAddress, string Subject, string Message);
    }
}