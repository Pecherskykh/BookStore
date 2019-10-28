using BookStore.BusinessLogic.Models.Orders;
using BookStore.DataAccess.Models.OrdersFilterModel;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModel> GetOrdersAsync(OrdersFilterModel ordersFilterModel);
    }
}
