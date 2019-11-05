using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Cart;
using BookStore.BusinessLogic.Models.Orders;
using BookStore.DataAccess.Models.OrdersFilterModel;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModelItem> FindByIdAsync(long orderId);
        Task<BaseModel> CreateAsync(CartModel cartModel);
        Task<OrderModel> GetOrdersAsync(OrdersFilterModel ordersFilterModel);
    }
}
