using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task CreateAsync(OrderItem orderItem);
        Task<OrderItem> GetAsync(long OrderItemId);
        Task UpdateAsync();
        Task DeleteAsync(long orderItemId);
    }
}
