﻿using BookStore.DataAccess.Models.Base;
using static BookStore.DataAccess.Models.Enums.Enums;
using static BookStore.DataAccess.Models.Enums.Enums.UserFilterEnums;

namespace BookStore.DataAccess.Models.UesrsFilterModel
{
    public class UsersFilterModel : BaseModel
    {
        public SortType SortType { get; set; }
        public SortingDirection SortingDirection { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}