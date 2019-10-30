using BookStore.DataAccess.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static BookStore.DataAccess.Models.Enums.Enums.OrdersFilterEnums;

namespace BookStore.DataAccess.Models.OrdersFilterModel
{
    public class OrdersFilterModel : BaseModel
    {
        public SortingDirection SortingDirection { get; set; }
        public SortType SortType { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
