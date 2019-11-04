using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.Orders;
using BookStore.DataAccess.Models.OrdersFilterModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
     public interface IOrderRepository : IBaseEFRepository<Order>
     {
        Task<IEnumerable<OrderModelItem>> GetOrdersAsync(OrdersFilterModel ordersFilterModel);
     }
}
