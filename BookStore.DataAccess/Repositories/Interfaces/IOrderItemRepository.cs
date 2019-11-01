using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IOrderItemRepository : IBaseEFRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetOrdersItemAsync(long OrderId);
    }
}
