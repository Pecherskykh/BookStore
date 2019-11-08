using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Common.Constants
{
    public partial class Constants
    {
        public class JwtConstants
        {
            public const decimal ExpiresAccessToken = 1;
            public const decimal ExpiresRefreshToken = 60;
        }
    }
}
