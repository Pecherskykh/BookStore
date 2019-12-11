using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Extensions.OrderExtensions;
using BookStore.BusinessLogic.Extensions.OrderItemExtensions;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Cart;
using BookStore.BusinessLogic.Models.Orders;
using BookStore.BusinessLogic.Models.OrdersFilterModel;
using BookStore.BusinessLogic.Extensions.OrdersFilterExtensions;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Interfaces;
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
            if (orderId == 0)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.OrderIdIsZeroError);
                return resultModel;
            }
            var order = await _orderRepository.FindByIdAsync(orderId);
            if (order == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.OrderNotFoundError);
                return resultModel;
            }
            return order.Map();
        }

        public async Task<BaseModel> CreateAsync(CartModel cartModel)
        {
            var resultModel = new BaseModel();
            if(cartModel == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.CartModelIsEmptyError);
                return resultModel;
            }
            var payment = new Payment()
            {
                TransactionId = cartModel.TransactionId
            };
            var paymentId = await _paymentRepository.CreateAsync(payment);
            var order = new Order()
            {
                PaymentId = paymentId,
                UserId = cartModel.UserId
            };
            var orderId = await _orderRepository.CreateAsync(order);
            foreach (var orderItem in cartModel.OrderItemModel.Items)
            {
                orderItem.OrderId = orderId;
                var orderItemEntity = orderItem.Map();
                await _orderItemRepository.CreateAsync(orderItemEntity);
            }
            return resultModel;
        }

        public async Task<OrderModel> GetOrdersAsync(OrdersFilterModel ordersFilterModel)
        {
            var resultModel = new OrderModel();
            if (ordersFilterModel == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.OrdersFilterModelIsEmptyError);
                return resultModel;
            }
            resultModel = (await _orderRepository.GetOrdersAsync(ordersFilterModel.Map())).Map();
            return resultModel;
        }
    }
}
