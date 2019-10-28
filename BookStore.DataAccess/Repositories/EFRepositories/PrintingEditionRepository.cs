using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Extensions;
using BookStore.DataAccess.Models.PrintingEditions;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<PrintingEditionModelItem>> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModel)
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


            printingEditions = await OrderBy(printingEditions, printingEditionsFilterModel.SortBy, printingEditionsFilterModel.SortingDirection == SortingDirection.LowToHigh);

            printingEditions = printingEditions.Where(p => p.Price >= printingEditionsFilterModel.MinPrice && p.Price <= printingEditionsFilterModel.MaxPrice);
            
            printingEditions = printingEditions.Skip((printingEditionsFilterModel.PageCount - 1) * printingEditionsFilterModel.PageSize).Take(printingEditionsFilterModel.PageSize);

            return printingEditions;
        }

        private async Task<IQueryable<PrintingEditionModelItem>> OrderBy(IQueryable<PrintingEditionModelItem> printingEditions, SortBy sortBy, bool lowToHigh)
        {
            if (sortBy == SortBy.Author)
            {
                return printingEditions.OrderDirection(a => a.Description, lowToHigh);
            }
            if (sortBy == SortBy.Category)
            {
                return printingEditions.OrderDirection(c => c.Type, lowToHigh);
            }
            if (sortBy == SortBy.Discription)
            {
                return printingEditions.OrderDirection(d => d.Description, lowToHigh);
            }
            if (sortBy == SortBy.Id)
            {
                return printingEditions.OrderDirection(i => i.Id, lowToHigh);
            }
            if (sortBy == SortBy.Name)
            {
                return printingEditions.OrderDirection(t => t.Title, lowToHigh);
            }
            if (sortBy == SortBy.Price)
            {
                return printingEditions.OrderDirection(p => p.Price, lowToHigh);
            }
            return printingEditions;
        }        
    }
}
