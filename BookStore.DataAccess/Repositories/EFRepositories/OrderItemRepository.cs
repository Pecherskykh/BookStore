using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class OrderItemRepository : BaseEFRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<OrderItem>> GetOrdersItemAsync(long OrderId)
        {
            return _applicationContext.OrderItems.Where(o => o.OrderId == OrderId);
        }
    }
}
