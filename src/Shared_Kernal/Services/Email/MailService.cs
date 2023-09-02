using ecommerce_shared.Exceptions;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace ecommerce_shared.Services.Email
{
    public class MailService : IMailService
    {

        private readonly MailSetting MailSetting;

        public MailService(IOptions<MailSetting> MailSetting) {


            this.MailSetting = MailSetting.Value;
        }
        public bool SendMail(string Email, string message)
        {
            try
            {

                using MimeMessage emailMessage = new MimeMessage();
                emailMessage.From.Add(MailboxAddress.Parse(MailSetting.From));
                emailMessage.To.Add(MailboxAddress.Parse(Email));
                emailMessage.Subject = "Reset Password Ecommerce :)";
                emailMessage.Body = new TextPart(TextFormat.Text)
                {
                    Text=message

                };
                using SmtpClient mailClient = new SmtpClient();

                mailClient.Connect(MailSetting.SmtpServer,MailSetting.Port,MailKit.Security.SecureSocketOptions.StartTls);
                mailClient.Authenticate(MailSetting.Username,MailSetting.Password); 
                mailClient.Send(emailMessage);
                mailClient.Disconnect(true);
                return true;
            }
            catch (Exception ex){

                throw new CannotSendEmailException(ex.Message);


            }




        }
    }
}
