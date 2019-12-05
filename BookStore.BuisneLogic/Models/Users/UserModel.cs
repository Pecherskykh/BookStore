﻿using BookStore.BusinessLogic.Models.Base;
using System.Collections.Generic;

namespace BookStore.BusinessLogic.Models.Users
{
    public class UserModel : BaseModel
    {
        public long Count { get; set; } 
        public ICollection<UserModelItem> Items { get; set; } = new List<UserModelItem>();
    }
}
