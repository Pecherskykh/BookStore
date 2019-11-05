using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Helpers.Interfaces
{
    public interface ICreatePasswordHelper
    {
        string CreatePassword(int length);
    }
}
