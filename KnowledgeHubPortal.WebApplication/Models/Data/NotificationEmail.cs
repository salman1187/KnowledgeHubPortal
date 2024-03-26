using KnowledgeHubPortal.WebApplication.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace KnowledgeHubPortal.WebApplication.Models.Data
{
    public class NotificationEmail : INotificationMedium
    {
        public void Send(string to, string subject, string message)
        {
            MailMessage msg = new MailMessage("2002syeds@gmail.com", to);
            msg.Subject = subject;
            msg.Body = message;
            msg.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("2002syeds@gmail.com", "svch dcts gwjl fohj");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;

            smtp.Send(msg);


        }
    }
}