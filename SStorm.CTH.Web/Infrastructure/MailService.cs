using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SStorm.CTH.Web
{
    public class MailService : IMailService
    {
        public IConfiguration Configuration { get; }
        public MailService(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void SendEmail(string EmailTo, string title, string Body, params Attachment[] Attachments)
        {
            SendEmail(new string[] { EmailTo }, title, Body, Attachments);
        }
        public void SendEmail(string[] EmailTo, string title, string Body, params Attachment[] Attachments)
        {

            var MailServiceConfig = Configuration.GetSection("MailService");

            bool EnableSSL = false;
            string Host = MailServiceConfig["Host"];
            int Port = int.Parse(MailServiceConfig["Port"]);
            string UserName = MailServiceConfig["UserName"];
            string Password = MailServiceConfig["Password"];
            string Address = MailServiceConfig["Address"];
            string DisplayName = MailServiceConfig["DisplayName"];

            MailAddressCollection to = new MailAddressCollection();
            MailMessage msg = new MailMessage();

            SmtpClient smtp;

            smtp = new SmtpClient();




            smtp.EnableSsl = EnableSSL;
            smtp.Host = Host;
            smtp.Port = Port;
            //smtp.TargetName = setting.TargetName;
            smtp.Credentials = new NetworkCredential(UserName, Password);


            foreach (string item in EmailTo)
            {
                try
                {
                    Regex exp = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.IgnoreCase);

                    if (exp.IsMatch(item))
                    {
                        msg.To.Add(item);
                    }

                }
                catch
                {
                    return;
                }
            }
            if (msg.To.Count == 0) return;

            msg.From = new MailAddress(Address, DisplayName);
            msg.Subject = title;
            msg.Body = Body;
            msg.IsBodyHtml = true;
            foreach (var item in Attachments)
            {
                msg.Attachments.Add(item);
            }

            try
            {
                smtp.Send(msg);
            }
            catch (SmtpException)
            {

            }
        }
    }
}
