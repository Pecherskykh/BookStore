using Microsoft.Extensions.Configuration;

namespace BookStore.BusinessLogic.Common.Constants
{
    public partial class Constants
    {
        public class EmailConstants
        {
            public const string Address = "testmailproject24@gmail.com";
            public const string Password = "12345mail";
            public const string Host = "smtp.gmail.com";
            public const int Port = 587;
            public const string ConfirmEmail = "http://localhost:52976/api/account/confirmEmail?userId={0}&token={1}";
        }
    }
}
