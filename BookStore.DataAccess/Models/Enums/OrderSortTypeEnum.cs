using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Models.Enums
{
    public partial class Enums
    {
        public partial class OrdersFilterEnums
        {
            public enum SortType
            {
                Id = 1,
                Date = 2,
                UserName = 3,
                UserEmail = 4,
                OrderAmount = 8,
            }
        }
    }
}