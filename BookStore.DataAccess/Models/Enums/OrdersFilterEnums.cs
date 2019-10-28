using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Models.Enums
{
    public partial class Enums
    {
        public class OrdersFilterEnums
        {
            public enum SortBy
            {
                Id = 1,
                Date = 2,
                UserName = 3,
                UserEmail = 4,
                Product = 5,
                Title = 6,
                Qty = 7,
                OrderAmount = 8,
                Status = 9
            }

            public enum SortingDirection
            {
                LowToHigh = 1,
                HighToLow = 2
            }

            public enum OrderStatus
            {
                Paid = 1,
                Unpaid = 2
            }
        }
    }
}