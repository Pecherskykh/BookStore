using BookStore.DataAccess.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static BookStore.DataAccess.Models.UesrsFilterModel.Enums.UesrsFilterEnums;

namespace BookStore.DataAccess.Models.UesrsFilterModel
{
    public class UsersFilter : BaseModel
    {
        public Sorted Sorted { get; set; }
        public UserActive UserActive { get; set; }
    }
}