using BookStore.BusinessLogic.Models.Base;
using static BookStore.BusinessLogic.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Models.OrderItems
{
    public class OrderItemModelItem : BaseModel
    {
        public long Amount { get; set; }
        public Currencys Currency { get; set; }
        public long Count { get; set; }
        public long OrderId { get; set; }
        public long PrintingEditionId { get; set; }
    }
}
