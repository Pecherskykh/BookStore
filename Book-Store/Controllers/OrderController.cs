using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Models.OrdersFilterModel;
using Microsoft.AspNetCore.Mvc;
using static BookStore.DataAccess.Models.Enums.Enums.OrdersFilterEnums;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test(/*OrdersFilterModel ordersFilterModel*/)
        {
            var ordersFilterModel = new OrdersFilterModel
            {
                SortBy = SortBy.UserName,
                SortingDirection = SortingDirection.HighToLow,
                OrderStatus = OrderStatus.Unpaid,
                PageCount = 1,
                PageSize = 10
            };
            var authorModel = await _orderService.GetOrdersAsync(ordersFilterModel);
            return Ok(authorModel);
        }
    }
}