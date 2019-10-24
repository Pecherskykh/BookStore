using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.PrintingEditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models.Orders
{
    public class OederItemModel : BaseModel
    {
        public int Amount { get; set; }
        public string Currency { get; set; }
        public int Count { get; set; }
        public int PrintingEditionId { get; set; }
        public PrintingEditionModelItem PrintingEdition { get; set; }
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
    }
}
