using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Cart;
using BookStore.BusinessLogic.Models.OrdersFilterModel;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(ordersModel);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CartModel cartModel) //todo get model from body
        {
            var ordersModel = await _orderService.CreateAsync(cartModel);
            return Ok(ordersModel);
        }
    }
}