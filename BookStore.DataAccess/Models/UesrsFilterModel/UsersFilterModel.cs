using BookStore.DataAccess.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static BookStore.DataAccess.Models.Enums.Enums.UserFilterEnums;

namespace BookStore.DataAccess.Models.UesrsFilterModel
{
    public class UsersFilterModel : BaseModel
    {
        public SortBy SortBy { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}