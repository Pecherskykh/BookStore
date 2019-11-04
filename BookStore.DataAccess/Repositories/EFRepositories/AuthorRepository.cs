using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Interfaces;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Models.Authors;
using BookStore.DataAccess.Extensions;
using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class AuthorRepository : BaseEFRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<AuthorModelItem>> GetAuthorsAsync(SortingDirection sortingDirection)
        {
            var authors = from author in _applicationContext.Authors where author.IsRemoved == false
                          select new AuthorModelItem
                          {
                              Id = author.Id,
                              Name = author.Name,
                              PrintingEditions = (from authorInPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                                  join printingEdition in _applicationContext.PrintingEditions on authorInPrintingEdition.PrintingEditionId equals printingEdition.Id
                                                  where authorInPrintingEdition.AuthorId == author.Id
                                                  select printingEdition.Title).ToArray()
                          };

            authors = authors.OrderDirection(a => a.Id, sortingDirection == SortingDirection.LowToHigh);

            return authors;
        }
    }
}
