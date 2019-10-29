using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Helpers
{
    public class EmailHelper : IEmailHelper
    {
        public async Task Send(string email, string message)
        {
            var from = new MailAddress(Constants.EmailConstants.Address, "Name");
            var to = new MailAddress(email);
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage(from, to);
            mailMessage.Subject = "Test";
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient(Constants.EmailConstants.Host, Constants.EmailConstants.Port); //use Using
            smtp.Credentials = new NetworkCredential(Constants.EmailConstants.Address, Constants.EmailConstants.Password); //use constants
            smtp.EnableSsl = true;
            smtp.SendAsync(mailMessage, null); //use Async
        }
    }
}
