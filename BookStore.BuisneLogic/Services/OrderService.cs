using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Orders;
using BookStore.BusinessLogic.Services.BaseService;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities.Enums;
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

        public async Task<OrderModelItem> FindByIdAsync(long orderId)
        {
            var resultModel = new OrderModelItem();
            var order = await _orderRepository.FindByIdAsync(orderId);
            if (order == null)
            {
                resultModel.Errors.Add(EmailConstants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            return order.Mapping();
        }

        public async Task<long> CreateAsync(OrderModelItem order)
        {

            return await _orderRepository.CreateAsync(order.Mapping());
        }

        public async Task<BaseModel> UpdateAsync(OrderModelItem order)
        {
            await _orderRepository.UpdateAsync(order.Mapping());
            return new BaseModel();
        }

        public async Task<BaseModel> RemoveAsync(OrderModelItem order)
        {
            await _orderRepository.RemoveAsync(order.Mapping());
            return new BaseModel();
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
