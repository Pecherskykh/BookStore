using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.PrintingEditions;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionRepository : IBaseEFRepository<PrintingEdition>
    {
        Task<IEnumerable<PrintingEditionModelItem>> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels);
    }
}
