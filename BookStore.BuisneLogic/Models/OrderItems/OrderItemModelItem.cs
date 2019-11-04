using BookStore.BusinessLogic.Models.Base;
using static BookStore.DataAccess.Entities.Enums.Enums.CurrencyEnum;

namespace BookStore.BusinessLogic.Models.OrderItems
{
    public class OrderItemModelItem : BaseModel
    {
        public int Amount { get; set; }
        public Currencys Currency { get; set; }
        public int Count { get; set; }
        public long OrderId { get; set; }
        public long PrintingEditionId { get; set; }
    }
}
