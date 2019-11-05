using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Extensions
{
    public static class StringExtensions
    {
        public static string CheckGap(this string str)
        {
            if (!str.Contains(" "))
            {
                return str;
            }
            return str.Replace(" ", "+");
        }
    }
}
