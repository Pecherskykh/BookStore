using System;
using BookStore.BusinessLogic.Common.Constants;
using System.Text;
using BookStore.BusinessLogic.Helpers.Interfaces;

namespace BookStore.BusinessLogic.Helpers
{
    public class CreatePasswordHelper : ICreatePasswordHelper
    {
        public string CreatePassword(int length)
        {
            var result = new StringBuilder();
            var random = new Random();
            for (int i = length; i > 0; --i)
            {
                result.Append(Constants.PasswordConstans.ValidationString[random.Next(Constants.PasswordConstans.ValidationString.Length)]);
            }
            return result.ToString();
        }
    }
}