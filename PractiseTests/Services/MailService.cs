namespace PractiseTests.Services
{
    public class MailService : IMailService
    {
        private readonly ILogger<MailService> _logger;

        public MailService(ILogger<MailService> logger)
        {
            _logger = logger;
        }
        public void SendMessage(string Name, string FromEmailAddress , string ToEmailAddress, string Subject, string Message)
        {
            _logger.LogInformation($"To: {FromEmailAddress}, From : {ToEmailAddress} , Subject : {Subject}, message : {Message}");
        }
        
    }
}
