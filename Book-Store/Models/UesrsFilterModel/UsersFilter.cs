using BookStore.Presentation.Models.UesrsFilterModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Presentation.Models.UesrsFilterModel
{
    public class UsersFilter
    {
        string SearchString { get; set; }
        public Sorted sorted { get; set; }
        public UserActive userActive { get; set; }
    }
}