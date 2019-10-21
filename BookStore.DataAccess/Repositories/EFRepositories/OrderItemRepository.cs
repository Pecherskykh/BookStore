using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ApplicationContext _applicationContext;

        public OrderItemRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task CreateAsync(OrderItem orderItem)
        {
            _applicationContext.OrderItems.Add(orderItem);
            _applicationContext.SaveChanges();
        }

        public async Task<OrderItem> GetAsync(long OrderItemId)
        {
            return _applicationContext.OrderItems.FirstOrDefault(a => a.Id == OrderItemId);
        }

        public async Task UpdateAsync()
        {
            _applicationContext.SaveChanges();
        }

        public async Task DeleteAsync(long orderItemId)
        {
            _applicationContext.OrderItems.Remove(await GetAsync(orderItemId));
            _applicationContext.SaveChanges();
        }
    }
}
