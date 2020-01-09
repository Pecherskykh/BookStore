using BookStore.BusinessLogic.Models.Base;
using static BookStore.BusinessLogic.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Models.OrderItems
{
    public class OrderItemModelItem : BaseModel
    {
        public long Count { get; set; }
        public decimal UnitPrice { get; set; }
        public long OrderId { get; set; }
        public long PrintingEditionId { get; set; }
        public TypePrintingEdition Type { get; set; }
        public string Title { get; set; }
    }
}
