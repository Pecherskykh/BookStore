using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Orders;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Models.OrdersFilterModel;
using BookStore.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderModel> GetOrdersAsync(OrdersFilterModel ordersFilterModel)
        {
            var orders = await _orderRepository.GetOrdersAsync(ordersFilterModel);
            var resultModel = new OrderModel();
            foreach (var order in orders)
            {
                resultModel.Items.Add(order.Mapping());
            }
            return resultModel;
        }
    }
}
