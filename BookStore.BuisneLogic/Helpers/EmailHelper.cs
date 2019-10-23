using BookStore.BusinessLogic.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BookStore.BusinessLogic.Helpers
{
    public class EmailHelper : IEmailHelper
    {
        public void Send(string message)
        {
            var from = new MailAddress("testmailproject24@gmail.com", "Name");
            var to = new MailAddress("oleksandr.pecherskikh@gmail.com");
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(from, to);
            m.Subject = "Test";
            m.Body = message;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587); //use Using
            smtp.Credentials = new NetworkCredential("testmailproject24@gmail.com", "12345mail"); //use constants
            smtp.EnableSsl = true;
            smtp.Send(m); //use Async
        }
    }
}
