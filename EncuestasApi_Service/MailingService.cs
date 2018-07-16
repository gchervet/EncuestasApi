using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasApi_Service
{
    public class MailingService
    {
        public static void SendAutomatedEmail(string htmlString, string recipe)
        {
            try
            {
                MailMessage message = new MailMessage("no-responder@kennedy.edu.ar", "gchervet@kennedy.edu.ar");
                message.IsBodyHtml = true;
                message.Body = htmlString;
                message.Subject = "Test Email";

                SmtpClient client = new SmtpClient();
                client.Host = "svrservicios01";
                client.Port = 25;

                var AuthenticationDetails = new NetworkCredential("adlive@kennedy.edu.ar", "+adlive-");
                client.Credentials = AuthenticationDetails;
                client.Send(message);
            }
            catch (Exception e)
            {

            }
        }
    }
}
