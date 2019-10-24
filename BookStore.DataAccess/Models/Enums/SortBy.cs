using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Models.Enums
{
    public partial class PrintingEditionsFilterEnums
    {
        public enum SortBy
        {
            Id = 1,
            Name = 2,
            Discription = 3,
            Category = 4,
            Author = 5,
            Price = 6
        }
    }
}
