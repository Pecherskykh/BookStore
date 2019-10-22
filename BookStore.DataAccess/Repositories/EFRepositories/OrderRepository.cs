using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    class OrderRepository
    {
        private readonly ApplicationContext _applicationContext;

        public OrderRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IEnumerable<Order>> GetAllUOrdersOrderByDateAsync()
        {
            return _applicationContext.Orders.OrderBy(o => o.CreationDate);
        }
    }
}
