using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Cart;
using BookStore.BusinessLogic.Models.OrderItems;
using BookStore.BusinessLogic.Models.OrdersFilterModel;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BookStore.DataAccess.Entities.Enums.Enums.CurrencyEnum;
using static BookStore.DataAccess.Models.Enums.Enums;
using static BookStore.DataAccess.Models.Enums.Enums.OrdersFilterEnums;

namespace BookStore.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //todo attrs
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("getOrders")]
        public async Task<IActionResult> GetOrders(OrdersFilterModel ordersFilterModel)
        {        
            var ordersModel = await _orderService.GetOrdersAsync(ordersFilterModel);
            return Ok(ordersFilterModel);
        }

        [HttpGet("create")]
        public async Task<IActionResult> Create() //todo get model from body
        {
            var cartModel = new CartModel() //todo remove hardCode
            {
                OrderItemModel = new OrderItemModel()
                {
                    Items = new List<OrderItemModelItem>()
                    {
                        new OrderItemModelItem()
                        {
                            Amount = 17,
                            Currency = Currencys.UAH,
                            Count = 8,
                            PrintingEditionId = 13
                        }
                    }
                },
                TransactionId = 7,
                Description = "Description",
                UserId = 50,
            };
            //var ordersModel = await _orderService.CreateAsync(cartModel);
            return Ok(cartModel);
        }
    }
}