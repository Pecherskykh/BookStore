using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Helper
{
    public class AuthOptions
    {
        public const string _issuer = "MyAuthServer";
        public const string _audience = "http://localhost:52976/";
        const string _key = "key123_74ABC5555";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key));
        }
    }
}
