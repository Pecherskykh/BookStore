using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Models.PrintingEditions;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BookStore.DataAccess.Entities.Enums.Enums;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionRepository : IBaseEFRepository<PrintingEdition>
    {
        Task<PrintingEditionModel> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels);
    }
}
