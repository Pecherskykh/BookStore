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
using Microsoft.EntityFrameworkCore;
using BookStore.DataAccess.Models.Base;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class AuthorRepository : BaseEFRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<AuthorModel> GetAuthorsAsync(BaseFilterModel baseFilterModel)
        {
            var resultModel = new AuthorModel();
            var authors = from author in _applicationContext.Authors where !author.IsRemoved
                          select new AuthorModelItem
                          {
                              Id = author.Id,
                              Name = author.Name,
                              PrintingEditions = (from authorInPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                                  join printingEdition in _applicationContext.PrintingEditions on authorInPrintingEdition.PrintingEditionId equals printingEdition.Id
                                                  where authorInPrintingEdition.AuthorId == author.Id
                                                  select printingEdition.Title).ToArray()
                          };

            if (!string.IsNullOrWhiteSpace(baseFilterModel.SearchString))
            {
                authors = authors.Where(a => a.Name.ToLower().Equals(baseFilterModel.SearchString.ToLower()));
            }

            authors = authors.OrderDirection(a => a.Id, baseFilterModel.SortingDirection == SortingDirection.LowToHigh);

            resultModel.PageAmount = authors.Count();

            authors = authors.Skip((baseFilterModel.PageCount) * baseFilterModel.PageSize).Take(baseFilterModel.PageSize);

            resultModel.Items = await authors.ToListAsync();
            return resultModel;
        }
    }
}