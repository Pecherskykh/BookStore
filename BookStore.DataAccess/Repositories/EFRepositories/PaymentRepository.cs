using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class PaymentRepository : BaseEFRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }
    }
}
