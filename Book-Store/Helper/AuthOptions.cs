using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.Presentation.Helper
{
    public class AuthOptions
    {
        public const string _issuer = "MyAuthServer"; //todo rename
        public const string _audience = "http://localhost:52976/";
        private const string _key = "key123_74ABC5555";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key));
        }
    }
}
