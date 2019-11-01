using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.Repositories.Interfaces;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Models.Authors;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class AuthorRepository : BaseEFRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<AuthorModelItem>> GetAuthorsAsync()
        {
            var Authors = from author in _applicationContext.Authors where author.IsRemoved == false
                          select new AuthorModelItem
                          {
                              Id = author.Id,
                              Name = author.Name,
                              PrintingEditions = (from authorInPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                                  join printingEdition in _applicationContext.PrintingEditions on authorInPrintingEdition.PrintingEditionId equals printingEdition.Id
                                                  where authorInPrintingEdition.AuthorId == author.Id
                                                  select printingEdition.Title).ToArray()
                          };

            return Authors;
        }
    }
}
