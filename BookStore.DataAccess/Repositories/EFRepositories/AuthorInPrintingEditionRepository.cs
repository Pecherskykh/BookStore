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
    public class AuthorInPrintingEditionRepository : BaseEFRepository<AuthorInPrintingEdition>, IAuthorInPrintingEditionRepository
    {
        public AuthorInPrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<AuthorInPrintingEdition>> GetAuthorInPrintingEditionsAsync(long printingEditionId)
        {
            var a = _applicationContext.Authors.Where(authorInPrintingEdition => authorInPrintingEdition.Id == 7);

            return _applicationContext.AuthorInPrintingEditions.Where(authorInPrintingEdition => authorInPrintingEdition.Id == 7);
        }
    }
}
