using BookStore.BusinessLogic.Models.OrderItems;
using BookStore.DataAccess.Entities;

namespace BookStore.BusinessLogic.Extensions.OrderItemExtensions
{
    public static class OrderItemModelItemMapToOrderItem
    {
        public static OrderItem Map(this OrderItemModelItem orderItem)
        {
            return new OrderItem()
            {
                Amount = orderItem.Amount,
                Currency = (DataAccess.Entities.Enums.Enums.Currencys)orderItem.Currency,
                Count = orderItem.Count,
                OrderId = orderItem.OrderId,
                PrintingEditionId = orderItem.PrintingEditionId
            };
        }
    }
}
