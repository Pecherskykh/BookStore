using BookStore.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IAuthorInPrintingEditionRepository : IBaseEFRepository<AuthorInPrintingEdition>
    {
        Task<IEnumerable<AuthorInPrintingEdition>> GetAuthorInPrintingEditionsAsync(long printingEditionId);
    }
}
