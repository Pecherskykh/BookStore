using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Extensions;
using BookStore.DataAccess.Models.OrderItems;
using BookStore.DataAccess.Models.Orders;
using BookStore.DataAccess.Models.OrdersFilterModel;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class OrderRepository : BaseEFRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {

        }        

        public async Task<OrderModel> GetOrdersAsync(OrdersFilterModel ordersFilterModel)
        {
            var resultModel = new OrderModel();

            var orders = from order in _applicationContext.Orders join user in _applicationContext.Users on order.UserId equals user.Id
                         select new OrderModelItem
                                   {
                                       Id = order.Id,
                                       Date = order.CreationDate,
                                       UserName = user.UserName,
                                       UserEmail = user.Email,
                                       OrderItems = (from orderItem in _applicationContext.OrderItems
                                                     join printingEdition in _applicationContext.PrintingEditions
                                                     on orderItem.PrintingEditionId equals printingEdition.Id
                                                     where orderItem.OrderId == order.Id
                                                     select new OrderItemModelItem
                                                     {
                                                         Type = printingEdition.Type,
                                                         Title = printingEdition.Title,
                                                         Count = orderItem.Count
                                                     }).ToList(),
                                       OrderAmount = 54,
                                   };

            orders = OrderBy(orders, ordersFilterModel.SortType, ordersFilterModel.SortingDirection == SortingDirection.LowToHigh);

            var remainder = orders.Count() % ordersFilterModel.PageSize;
            if (remainder > 0)
            {
                resultModel.PageAmount = (orders.Count() - remainder) / ordersFilterModel.PageSize + 1;
            }

            if (remainder == 0)
            {
                resultModel.PageAmount = orders.Count() / ordersFilterModel.PageSize;
            }

            orders = orders.Skip((ordersFilterModel.PageCount - 1) * ordersFilterModel.PageSize).Take(ordersFilterModel.PageSize);

            resultModel.Items = await orders.ToListAsync();

            return resultModel;
        }

        private IQueryable<OrderModelItem> OrderBy(IQueryable<OrderModelItem> orders, OrderSortType sortType, bool lowToHigh)
        {
            if (sortType == OrderSortType.Id)
            {
                return orders.OrderDirection(i => i.Id, lowToHigh);
            }
            if (sortType == OrderSortType.Date)
            {
                return orders.OrderDirection(d => d.Date, lowToHigh);
            }
            if (sortType == OrderSortType.UserName)
            {
                return orders.OrderDirection(n => n.UserName, lowToHigh);
            }
            if (sortType == OrderSortType.UserEmail)
            {
                return orders.OrderDirection(e => e.UserEmail, lowToHigh);
            }           
            if (sortType == OrderSortType.OrderAmount)
            {
                return orders.OrderDirection(o => o.OrderAmount, lowToHigh);
            }
            return orders;
        }
    }
}
