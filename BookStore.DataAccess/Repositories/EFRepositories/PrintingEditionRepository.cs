using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.PrintingEditions;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookStore.DataAccess.Models.Enums.Enums.PrintingEditionsFilterEnums;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<IEnumerable<PrintingEditionModelItem>> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels)
        {

            /*var printingEditions = (from a in _applicationContext.AuthorInPrintingEditions
                         join p in _applicationContext.PrintingEditions on a.PrintingEditionId equals p.Id
                         join aut in _applicationContext.Authors on a.AuthorId equals aut.Id
                            select new {
                                PrintingEditionId = p.Id,
                                Title = p.Title,
                                Price = p.Price, 
                                Type = p.Type, 
                                Name = aut.Name
                            }).ToArray();*/

            var printingEditions = from printingEdition in _applicationContext.PrintingEditions
                                   select new PrintingEditionModelItem
                                   {
                                       Id = printingEdition.Id,
                                       Title = printingEdition.Title,
                                       Price = printingEdition.Price,
                                       Description = printingEdition.Description,
                                       Type = printingEdition.Type,
                                       AuthorsNames = (from authorInPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                                     join author in _applicationContext.Authors on authorInPrintingEdition.AuthorId equals author.Id
                                                     where (authorInPrintingEdition.PrintingEditionId == printingEdition.Id)
                                                     select author.Name).ToArray()
                                   };

            if (!string.IsNullOrWhiteSpace(printingEditionsFilterModels.SearchString))
            {
                printingEditions = printingEditions.Where(p => p.Title.Equals(printingEditionsFilterModels.SearchString));
            }

            if (printingEditionsFilterModels.SortingDirection == SortingDirection.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Author)
            {
                printingEditions = printingEditions.OrderBy(a => a.Description);
            }
            if (printingEditionsFilterModels.SortingDirection == SortingDirection.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Category)
            {
                printingEditions = printingEditions.OrderBy(c => c.Type);
            }
            if (printingEditionsFilterModels.SortingDirection == SortingDirection.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Discription)
            {
                printingEditions = printingEditions.OrderBy(d => d.Description);
            }
            if (printingEditionsFilterModels.SortingDirection == SortingDirection.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Id)
            {
                printingEditions = printingEditions.OrderBy(i => i.Id);
            }
            if (printingEditionsFilterModels.SortingDirection == SortingDirection.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Name)
            {
                printingEditions = printingEditions.OrderBy(t => t.Title);
            }
            if (printingEditionsFilterModels.SortingDirection == SortingDirection.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Price)
            {
                printingEditions = printingEditions.OrderBy(p => p.Price);
            }

            if (printingEditionsFilterModels.SortingDirection == SortingDirection.HighToLow && printingEditionsFilterModels.SortBy == SortBy.Author)
            {
                printingEditions = printingEditions.OrderByDescending(a => a.AuthorsNames);
            }
            if (printingEditionsFilterModels.SortingDirection == SortingDirection.HighToLow && printingEditionsFilterModels.SortBy == SortBy.Category)
            {
                printingEditions = printingEditions.OrderByDescending(c => c.Type);
            }
            if (printingEditionsFilterModels.SortingDirection == SortingDirection.HighToLow && printingEditionsFilterModels.SortBy == SortBy.Discription)
            {
                printingEditions = printingEditions.OrderByDescending(d => d.Description);
            }
            if (printingEditionsFilterModels.SortingDirection == SortingDirection.HighToLow && printingEditionsFilterModels.SortBy == SortBy.Id)
            {
                printingEditions = printingEditions.OrderByDescending(i => i.Id);
            }
            if (printingEditionsFilterModels.SortingDirection == SortingDirection.HighToLow && printingEditionsFilterModels.SortBy == SortBy.Name)
            {
                printingEditions = printingEditions.OrderByDescending(t => t.Title);
            }
            if (printingEditionsFilterModels.SortingDirection == SortingDirection.HighToLow && printingEditionsFilterModels.SortBy == SortBy.Price)
            {
                printingEditions = printingEditions.OrderByDescending(p => p.Price);
            }

            printingEditions = printingEditions.Where(p => p.Price >= printingEditionsFilterModels.MinPrice && p.Price <= printingEditionsFilterModels.MaxPrice);
            
            printingEditions = printingEditions.Skip((printingEditionsFilterModels.PageCount - 1) * printingEditionsFilterModels.PageSize).Take(printingEditionsFilterModels.PageSize);

            return printingEditions;
        }
    }
}
