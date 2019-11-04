using BookStore.BusinessLogic.Models.Base;
using System;
using static BookStore.DataAccess.Entities.Enums.Enums;

namespace BookStore.BusinessLogic.Models.Orders
{
    public class OrderModelItem : BaseModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public TypePrintingEditionEnum.Type Product { get; set; }
        public string Title { get; set; }
        public long Quantity { get; set; }
        public long OrderAmount { get; set; }
        public string Status { get; set; }
    }
}
