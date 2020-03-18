using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Email
{
    public static class HotmailEMail
    {

        public static void SendEmail(/*string pageVisted*/)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("nivag_17@hotmail.com", "2bDAMNEDsham69");
            SmtpServer.EnableSsl = true;

            try
            {
                MailMessage message = new MailMessage
                {
                    From = new MailAddress("nivag_17@hotmail.com")
                };
                message.To.Add("nivag_17@hotmail.com");
                message.Subject = "ISpy: Restricted WebSite has been visited.";
                message.Body = DateTime.Now + $": Restricted Webpage #NAME GOES HERE# visted.";

                Send(message, SmtpServer);               
            }   
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void Send(MailMessage mail, SmtpClient SmtpServer)
        {
            SmtpServer.Send(mail);
        }
    }
}
