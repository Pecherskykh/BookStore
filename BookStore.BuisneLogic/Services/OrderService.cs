using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Cart;
using BookStore.BusinessLogic.Models.Orders;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Models.OrdersFilterModel;
using BookStore.DataAccess.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IPaymentRepository _paymentRepository;

        public OrderService(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IPaymentRepository paymentRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<OrderModelItem> FindByIdAsync(long orderId)
        {
            var resultModel = new OrderModelItem();
            var order = await _orderRepository.FindByIdAsync(orderId);
            if (order == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            return order.Mapping();
        }

        public async Task<long> CreateAsync(Cart cart)
        {
            var payment = new Payment()
            {
                TransactionId = (int)cart.TransactionId
            };
            var paymentId = await _paymentRepository.CreateAsync(payment);
            var order = new Order()
            {
                Description = cart.Description,
                PaymentId = (int)paymentId,
                UserId = (int)cart.userId
            };
            var orderId = await _orderRepository.CreateAsync(order);
            foreach (var orderItems in cart.OrderItemModel.Items)
            {
                orderItems.OrderId = orderId;
                await _orderItemRepository.CreateAsync(orderItems.Mapping());
            }
            return orderId;
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
            order.IsRemoved = true;
            await _orderRepository.UpdateAsync(order.Mapping());
            var payment = await _paymentRepository.FindByIdAsync(order.PaymentId);
            payment.IsRemoved = true;
            await _paymentRepository.UpdateAsync(payment);
            var orderItems = (await _orderItemRepository.GetOrdersItemAsync(order.Id)).ToList();
            foreach (var orderItem in orderItems)
            {
                orderItem.IsRemoved = true;
                await _orderItemRepository.UpdateAsync(orderItem);
            }
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
