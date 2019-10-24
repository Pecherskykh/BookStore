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
        private /*const*/ string _adress; //= Common.Constants.EmailHelper.Address;
        public /*const*/ string _password; //= Common.Constants.EmailHelper.Password;
        public /*const*/ string _host; //= Common.Constants.EmailHelper.Host;
        public /*const*/ int _port; //= Common.Constants.EmailHelper.Port;
        public void Send(string message)
        {
            var from = new MailAddress(_adress, "Name");
            var to = new MailAddress("oleksandr.pecherskikh@gmail.com");
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(from, to);
            m.Subject = "Test";
            m.Body = message;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient(_host, _port); //use Using
            smtp.Credentials = new NetworkCredential(_adress, _password); //use constants
            smtp.EnableSsl = true;
            smtp.Send(m); //use Async
        }
    }
}
