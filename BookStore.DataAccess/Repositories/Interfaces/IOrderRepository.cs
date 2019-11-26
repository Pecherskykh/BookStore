using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Models.Orders;
using BookStore.DataAccess.Models.OrdersFilterModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
     public interface IOrderRepository : IBaseEFRepository<Order>
     {
        Task<OrderModel> GetOrdersAsync(OrdersFilterModel ordersFilterModel);
     }
}
