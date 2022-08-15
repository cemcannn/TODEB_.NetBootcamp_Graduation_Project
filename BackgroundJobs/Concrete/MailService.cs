using BackgroundJobs.Abstract;
using System;
using System.Net;
using System.Net.Mail;

namespace BackgroundJobs.Concrete
{
    public class MailService : IMailService
    {
        public void PasswordService(string to, string content)
        {
            MailMessage mail = new MailMessage();
            mail.Subject = "Your System Password";
            mail.From = new MailAddress("todebapartmentmanager@gmail.com", "Admin");
            mail.To.Add(new MailAddress($"{to}", $"{to}"));

            mail.IsBodyHtml = true;
            mail.Body = $"Your password is {content}";

            //Mail Priority
            mail.Priority = MailPriority.High;

            //SMTP/Sender information/Validation informatiın
            SmtpClient smtp = new SmtpClient("mtp.gmail.com", 465);
            NetworkCredential AccountInfo = new NetworkCredential("todebapartmentmanager@gmail.com", "a8oZyS]Exvwx");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = false;

            try
            {
                smtp.Send(mail);
                Console.WriteLine("Mail sent succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Send error: {0}", ex.Message));
            }
            Console.ReadKey();
        }
    }
}
