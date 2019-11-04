using System;
using BookStore.BusinessLogic.Common.Constants;
using System.Text;

namespace BookStore.BusinessLogic.Helpers
{
    static class CreatePasswordHelper //todo use DI
    {
        static public string CreatePassword(int length)
        {
            var resuslt = new StringBuilder(); //todo fix name
            var rnd = new Random(); //todo use fullName
            for (int i = length; i > 0; --i)
            {
                resuslt.Append(Constants.PasswordConstans.ValidationString[rnd.Next(Constants.PasswordConstans.ValidationString.Length)]);
            }
            return resuslt.ToString();
        }
    }
}