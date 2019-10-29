using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Helpers
{
    static class CreatePasswordHelper
    {
        static public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder resuslt = new StringBuilder();
            Random rnd = new Random();
            for (int i = length; i > 0; --i)
            {
                resuslt.Append(valid[rnd.Next(valid.Length)]);
            }
            return resuslt.ToString();
        }
    }
}
