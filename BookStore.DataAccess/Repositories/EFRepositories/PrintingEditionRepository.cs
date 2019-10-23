using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookStore.DataAccess.Models.PrintingEditionsFilterModels.Enums.PrintingEditionsFilterEnums;

namespace BookStore.DataAccess.Repositories.EFRepositories
{
    public class PrintingEditionRepository : IPrintingEditionRepository
    {
        private readonly ApplicationContext _applicationContext;

        public PrintingEditionRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task CreateAsync(PrintingEdition printingEdition)
        {
            _applicationContext.PrintingEditions.Add(printingEdition);
            _applicationContext.SaveChanges();
        }

        public async Task<PrintingEdition> GetAsync(long printingEditionId)
        {
            return _applicationContext.PrintingEditions.FirstOrDefault(p => p.Id == printingEditionId);
        }

        public async Task UpdateAsync()
        {
            _applicationContext.SaveChanges();
        }

        public async Task DeleteAsync(long printingEditionId)
        {
            _applicationContext.PrintingEditions.Remove(await GetAsync(printingEditionId));
            _applicationContext.SaveChanges();
        }

        public async Task PrintingEditionsAsync(PrintingEditionsFilterModels printingEditionsFilterModels)
        {

            var printingEditions = from a in _applicationContext.AuthorInPrintingEditions
                         join p in _applicationContext.PrintingEditions on a.PrintingEditionId equals p.Id
                         join aut in _applicationContext.Authors on a.AuthorId equals aut.Id
                            select new { Title = p.Title, p.Price, Name = aut.Name };

            if (!string.IsNullOrWhiteSpace(printingEditionsFilterModels.SearchString))
            {
                printingEditions = printingEditions.Where(p => p.Title == printingEditionsFilterModels.SearchString);
            }

            if (printingEditionsFilterModels.Sorted == Sorted.LowToHigh)
            {
                printingEditions = printingEditions.OrderBy(p => p.Price);
            }
            else if (printingEditionsFilterModels.Sorted == Sorted.HighToLow)
            {
                printingEditions = printingEditions.OrderByDescending(p => p.Price);
            }

            printingEditions = printingEditions.Where(p => p.Price >= printingEditionsFilterModels.MinPrice && p.Price <= printingEditionsFilterModels.MaxPrice);
            
            printingEditions = printingEditions.Skip((printingEditionsFilterModels.PageCount - 1) * printingEditionsFilterModels.PageSize).Take(printingEditionsFilterModels.PageSize);
        }
    }
}
