using BookStore.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IOrderItemRepository : IBaseEFRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetOrdersItemAsync(long OrderId);
    }
}
