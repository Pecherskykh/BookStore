using System;
using BookStore.BusinessLogic.Common.Constants;
using System.Text;

namespace BookStore.BusinessLogic.Helpers
{
    static class CreatePasswordHelper
    {
        static public string CreatePassword(int length)
        {
            StringBuilder resuslt = new StringBuilder();
            Random rnd = new Random();
            for (int i = length; i > 0; --i)
            {
                resuslt.Append(Constants.PasswordConstans.Valid[rnd.Next(Constants.PasswordConstans.Valid.Length)]);
            }
            return resuslt.ToString();
        }
    }
}