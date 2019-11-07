using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.Presentation.Helper
{
    public class AuthOptions
    {
        public const string Issuer = "MyAuthServer";
        public const string Audience = "http://localhost:52976/";
        private const string Key = "key123_74ABC5555";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}