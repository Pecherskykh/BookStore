using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookStore.DataAccess.Models.Enums.PrintingEditionsFilterEnums;
using static BookStore.DataAccess.Models.PrintingEditionsFilterModels.Enums.PrintingEditionsFilterEnums;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task PrintingEditionsAsync(PrintingEditionsFilterModels printingEditionsFilterModels)
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

            var printingEditions = from p in _applicationContext.PrintingEditions
                                    select new
                                    {
                                        PrintingEditionId = p.Id,
                                        Title = p.Title,
                                        Price = p.Price,
                                        Description = p.Description,
                                        Type = p.Type,
                                        AuthorName = (from a in _applicationContext.AuthorInPrintingEditions
                                               join print in _applicationContext.PrintingEditions on a.PrintingEditionId equals p.Id
                                               join author in _applicationContext.Authors on a.AuthorId equals author.Id where (print.Id == p.Id)
                                               select author.Name).ToArray()
                                    };

            //var parametr = from printingEdition in printingEditions group printingEdition by printingEdition.PrintingEditionId;

            if (!string.IsNullOrWhiteSpace(printingEditionsFilterModels.SearchString))
            {
                //string.Equals(string)
                //string.Equals(string,string)
                printingEditions = printingEditions.Where(p => p.Title.Equals(printingEditionsFilterModels.SearchString));
            }

            if (printingEditionsFilterModels.Sorted == Sorted.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Author)
            {
                printingEditions = printingEditions.OrderBy(a => a.AuthorName);
            }
            if (printingEditionsFilterModels.Sorted == Sorted.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Category)
            {
                printingEditions = printingEditions.OrderBy(c => c.Type);
            }
            if (printingEditionsFilterModels.Sorted == Sorted.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Discription)
            {
                printingEditions = printingEditions.OrderBy(d => d.Description);
            }
            if (printingEditionsFilterModels.Sorted == Sorted.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Id)
            {
                printingEditions = printingEditions.OrderBy(i => i.PrintingEditionId);
            }
            if (printingEditionsFilterModels.Sorted == Sorted.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Name)
            {
                printingEditions = printingEditions.OrderBy(t => t.Title);
            }
            if (printingEditionsFilterModels.Sorted == Sorted.LowToHigh && printingEditionsFilterModels.SortBy == SortBy.Price)
            {
                printingEditions = printingEditions.OrderBy(p => p.Price);
            }

            if (printingEditionsFilterModels.Sorted == Sorted.HighToLow && printingEditionsFilterModels.SortBy == SortBy.Author)
            {
                printingEditions = printingEditions.OrderByDescending(a => a.AuthorName);
            }
            if (printingEditionsFilterModels.Sorted == Sorted.HighToLow && printingEditionsFilterModels.SortBy == SortBy.Category)
            {
                printingEditions = printingEditions.OrderByDescending(c => c.Type);
            }
            if (printingEditionsFilterModels.Sorted == Sorted.HighToLow && printingEditionsFilterModels.SortBy == SortBy.Discription)
            {
                printingEditions = printingEditions.OrderByDescending(d => d.Description);
            }
            if (printingEditionsFilterModels.Sorted == Sorted.HighToLow && printingEditionsFilterModels.SortBy == SortBy.Id)
            {
                printingEditions = printingEditions.OrderByDescending(i => i.PrintingEditionId);
            }
            if (printingEditionsFilterModels.Sorted == Sorted.HighToLow && printingEditionsFilterModels.SortBy == SortBy.Name)
            {
                printingEditions = printingEditions.OrderByDescending(t => t.Title);
            }
            if (printingEditionsFilterModels.Sorted == Sorted.HighToLow)
            {
                printingEditions = printingEditions.OrderByDescending(p => p.Price);
            }

            printingEditions = printingEditions.Where(p => p.Price >= printingEditionsFilterModels.MinPrice && p.Price <= printingEditionsFilterModels.MaxPrice);
            
            printingEditions = printingEditions.Skip((printingEditionsFilterModels.PageCount - 1) * printingEditionsFilterModels.PageSize).Take(printingEditionsFilterModels.PageSize);
        }
    }
}
