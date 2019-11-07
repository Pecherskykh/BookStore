using BookStore.DataAccess.AppContext;
using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Extensions;
using BookStore.DataAccess.Models.Authors;
using BookStore.DataAccess.Models.PrintingEditions;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using BookStore.DataAccess.Repositories.Base;
using BookStore.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.DataAccess.Entities.Enums.Enums;
using static BookStore.DataAccess.Models.Enums.Enums;
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
            var printingEditions = from printingEdition in _applicationContext.PrintingEditions //where printingEdition.IsRemoved
                                   select new PrintingEditionModelItem
                                   {
                                       Id = printingEdition.Id,
                                       Title = printingEdition.Title,
                                       Price = printingEdition.Price,
                                       Description = printingEdition.Description,
                                       Type = printingEdition.Type,
                                       Authors = (from authorInPrintingEdition in _applicationContext.AuthorInPrintingEditions
                                                  join author in _applicationContext.Authors on authorInPrintingEdition.AuthorId equals author.Id
                                                  where (authorInPrintingEdition.PrintingEditionId == printingEdition.Id)
                                                  select new AuthorModelItem
                                                  {
                                                      Id = author.Id,
                                                      Name = author.Name
                                                  }).ToArray()
                                   };
            var allCategories = (Enum.GetValues(typeof(TypePrintingEditionEnum.Type))).OfType<TypePrintingEditionEnum.Type>().ToList();
            allCategories = allCategories.Where(x => !printingEditionsFilterModel.Categories.Contains(x)).ToList();
            foreach (var categoty in allCategories)
            {
                printingEditions = printingEditions.Where(x => x.Type != categoty);
            }

            printingEditions = OrderBy(printingEditions, printingEditionsFilterModel.SortType, printingEditionsFilterModel.SortingDirection == SortingDirection.LowToHigh);

            printingEditions = printingEditions.Where(p => p.Price >= printingEditionsFilterModel.MinPrice && p.Price <= printingEditionsFilterModel.MaxPrice);
            
            printingEditions = printingEditions.Skip((printingEditionsFilterModel.PageCount - 1) * printingEditionsFilterModel.PageSize).Take(printingEditionsFilterModel.PageSize);

            return await printingEditions.ToListAsync();
        }

        private IQueryable<PrintingEditionModelItem> OrderBy(IQueryable<PrintingEditionModelItem> printingEditions, SortType sortType, bool lowToHigh)
        {
            if (sortType == SortType.Author)
            {
                return printingEditions.OrderDirection(a => a.Description, lowToHigh);
            }
            if (sortType == SortType.Category)
            {
                return printingEditions.OrderDirection(c => c.Type, lowToHigh);
            }
            if (sortType == SortType.Discription)
            {
                return printingEditions.OrderDirection(d => d.Description, lowToHigh);
            }
            if (sortType == SortType.Id)
            {
                return printingEditions.OrderDirection(i => i.Id, lowToHigh);
            }
            if (sortType == SortType.Name)
            {
                return printingEditions.OrderDirection(t => t.Title, lowToHigh);
            }
            if (sortType == SortType.Price)
            {
                return printingEditions.OrderDirection(p => p.Price, lowToHigh);
            }
            return printingEditions;
        }        
    }
}