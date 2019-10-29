using BookStore.BusinessLogic.Models.Orders;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.OrdersFilterModel;
using BookStore.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IOrderService : IBaseService<Order, IOrderRepository>
    {
        Task<OrderModel> GetOrdersAsync(OrdersFilterModel ordersFilterModel);
    }
}
