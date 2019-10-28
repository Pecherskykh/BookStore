using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Extensions;
using BookStore.DataAccess.Models.Orders;
using BookStore.DataAccess.Models.OrdersFilterModel;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookStore.DataAccess.Models.Enums.Enums.OrdersFilterEnums;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class OrderRepository : BaseEFRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }        

        public async Task<IEnumerable<OrderModelItem>> GetOrdersAsync(OrdersFilterModel ordersFilterModel)
        {
            var orders = from order in _applicationContext.Orders join orderItem in _applicationContext.OrderItems on order.Id equals orderItem.OrderId
                                   join printingEdition in _applicationContext.PrintingEditions on orderItem.PrintingEditionId equals printingEdition.Id
                                   select new OrderModelItem
                                   {
                                       Id = order.Id,
                                       Date = order.CreationDate,
                                       UserName = _applicationContext.Users.Where(u => u.Id == order.UserId).Select(u => u.UserName).FirstOrDefault(),
                                       UserEmail = _applicationContext.Users.Where(u => u.Id == order.UserId).Select(u => u.UserName).FirstOrDefault(),
                                       Product = printingEdition.Type,
                                       Title = printingEdition.Title,
                                       Qty = orderItem.Count,
                                       OrderAmount = orderItem.Amount,
                                       Status = printingEdition.Status
                                   };
            orders = await OrderBy(orders, ordersFilterModel.SortBy, ordersFilterModel.SortingDirection == SortingDirection.LowToHigh);

            orders = orders.Skip((ordersFilterModel.PageCount - 1) * ordersFilterModel.PageSize).Take(ordersFilterModel.PageSize);

            return orders;
        }

        private async Task<IQueryable<OrderModelItem>> OrderBy(IQueryable<OrderModelItem> orders, SortBy sortBy, bool lowToHigh)
        {
            if (sortBy == SortBy.Id)
            {
                return orders.OrderDirection(i => i.Id, lowToHigh);
            }
            if (sortBy == SortBy.Date)
            {
                return orders.OrderDirection(d => d.Date, lowToHigh);
            }
            if (sortBy == SortBy.UserName)
            {
                return orders.OrderDirection(n => n.UserName, lowToHigh);
            }
            if (sortBy == SortBy.UserEmail)
            {
                return orders.OrderDirection(e => e.UserEmail, lowToHigh);
            }
            if (sortBy == SortBy.Product)
            {
                return orders.OrderDirection(p => p.Product, lowToHigh);
            }
            if (sortBy == SortBy.Title)
            {
                return orders.OrderDirection(t => t.Title, lowToHigh);
            }
            if (sortBy == SortBy.Qty)
            {
                return orders.OrderDirection(q => q.Qty, lowToHigh);
            }            
            if (sortBy == SortBy.OrderAmount)
            {
                return orders.OrderDirection(o => o.OrderAmount, lowToHigh);
            }
            if (sortBy == SortBy.Status)
            {
                return orders.OrderDirection(s => s.Status, lowToHigh);
            }
            return orders;
        }
    }
}
