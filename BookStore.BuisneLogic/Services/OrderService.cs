using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Orders;
using BookStore.BusinessLogic.Services.BaseService;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.OrdersFilterModel;
using BookStore.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    public class OrderService : BaseService<Order, IOrderRepository>, IOrderService
    {
        public OrderService(IOrderRepository _baseEFRepository) : base(_baseEFRepository)
        {
        }

        public async Task<OrderModelItem> FindByIdAsync(long orderId)
        {
            var resultModel = new OrderModelItem();
            var order = await _baseEFRepository.FindByIdAsync(orderId);
            if (order == null)
            {
                resultModel.Errors.Add(EmailConstants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            return order.Mapping();
        }

        public async Task<OrderModel> GetOrdersAsync(OrdersFilterModel ordersFilterModel)
        {
            var orders = await _baseEFRepository.GetOrdersAsync(ordersFilterModel);
            var resultModel = new OrderModel();
            foreach (var order in orders)
            {
                resultModel.Items.Add(order.Mapping());
            }
            return resultModel;
        }
    }
}
