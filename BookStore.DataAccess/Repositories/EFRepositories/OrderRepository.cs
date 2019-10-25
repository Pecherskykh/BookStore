using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    class OrderRepository : BaseEFRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }        

        public async Task<IEnumerable<Order>> GetAllUOrdersOrderByDateAsync()
        {
            return _applicationContext.Orders.OrderBy(o => o.CreationDate);
        }
    }
}
