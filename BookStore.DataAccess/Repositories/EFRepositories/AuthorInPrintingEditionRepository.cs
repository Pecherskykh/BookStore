using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class AuthorInPrintingEditionRepository : BaseEFRepository<AuthorInPrintingEdition>, IAuthorInPrintingEditionRepository
    {
        
        public AuthorInPrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<AuthorInPrintingEdition>> GetAuthorInPrintingEditionsAsync(long printingEditionId)
        {
            return _applicationContext.AuthorInPrintingEditions.Where(a => a.PrintingEditionId == printingEditionId);
        }
    }
}
