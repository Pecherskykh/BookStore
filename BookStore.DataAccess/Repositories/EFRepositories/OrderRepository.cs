using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Extensions;
using BookStore.DataAccess.Models.Orders;
using BookStore.DataAccess.Models.OrdersFilterModel;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
                                   join user in _applicationContext.Users on order.UserId equals user.Id where order.IsRemoved == false
                                   select new OrderModelItem
                                   {
                                       Id = order.Id,
                                       Date = order.CreationDate,
                                       UserName = user.UserName,
                                       UserEmail = user.Email,
                                       Product = printingEdition.Type,
                                       Title = printingEdition.Title,
                                       Quantity = orderItem.Count,
                                       OrderAmount = orderItem.Amount,
                                       Status = printingEdition.Status
                                   };
            orders = OrderBy(orders, ordersFilterModel.SortType, ordersFilterModel.SortingDirection == SortingDirection.LowToHigh);

            orders = orders.Skip((ordersFilterModel.PageCount - 1) * ordersFilterModel.PageSize).Take(ordersFilterModel.PageSize);

            return await orders.ToListAsync();
        }

        private IQueryable<OrderModelItem> OrderBy(IQueryable<OrderModelItem> orders, SortType sortType, bool lowToHigh)
        {
            if (sortType == SortType.Id)
            {
                return orders.OrderDirection(i => i.Id, lowToHigh);
            }
            if (sortType == SortType.Date)
            {
                return orders.OrderDirection(d => d.Date, lowToHigh);
            }
            if (sortType == SortType.UserName)
            {
                return orders.OrderDirection(n => n.UserName, lowToHigh);
            }
            if (sortType == SortType.UserEmail)
            {
                return orders.OrderDirection(e => e.UserEmail, lowToHigh);
            }           
            if (sortType == SortType.OrderAmount)
            {
                return orders.OrderDirection(o => o.OrderAmount, lowToHigh);
            }
            return orders;
        }
    }
}
