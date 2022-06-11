using Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.CustomExceptions;

namespace Implementation.Core
{
    public class SmtpEmailSender : IEmailSender
    {
        public void SendEmail(string subject, string emailingTo, string message)
        {
            try
            {
                var htmlString = "<html><head></head><body><p>" + message + "</p></body></html>";
                var Message = new MailMessage();
                var smpt = new SmtpClient();
                Message.From = new MailAddress("MoneyAppJelenaNaum@gmail.com");
                Message.To.Add(new MailAddress(emailingTo));
                Message.Subject = subject;
                Message.IsBodyHtml = true;
                Message.Body = htmlString;
                smpt.Host = "smtp.gmail.com";
                smpt.Port = 587;
                smpt.EnableSsl = true;
                smpt.UseDefaultCredentials = false;
                smpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                smpt.Credentials = new NetworkCredential("MoneyAppJelenaNaum@gmail.com", "Solsker1234");
                smpt.Send(Message);
            }
            catch(Exception ex)
            {
                throw new FailedToSendEmailException(ex.Message);
            }
        }
    }
}
