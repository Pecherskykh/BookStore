using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BookStore.BusinessLogic.Helpers
{
    public class EmailHelper
    {
        public void Send(string message)
        {
            MailAddress from = new MailAddress("testmailproject24@gmail.com", "Name");
            MailAddress to = new MailAddress("oleksandr.pecherskikh@gmail.com");
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(from, to);
            m.Subject = "Test";
            m.Body = message;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("testmailproject24@gmail.com", "12345mail");
            smtp.EnableSsl = true;
            smtp.Send(m);
        }
    }
}
