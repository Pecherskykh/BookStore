using BookStore.BusinessLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models.Users
{
    public class UserModel : BaseModel
    {
        public ICollection<UserModelItem> Items = new List<UserModelItem>();
    }
}
