
using Microsoft.Extensions.Options;
using MVCCoreTemplate.Business.Abstract;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
namespace MVCCoreTemplate.Business.Concrete
{
    // This class is used by the application to send email 
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } 

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string api, string subject, string message, string email)
        {
            //TODO : Set this via SecretManager
            var client = new SendGridClient("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");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("cigdem.kocuzun@gmail.com", "Invicti"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            return client.SendEmailAsync(msg);
        }

    }
}