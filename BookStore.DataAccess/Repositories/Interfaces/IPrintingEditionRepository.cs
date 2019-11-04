using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.PrintingEditions;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BookStore.DataAccess.Entities.Enums.Enums;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IPrintingEditionRepository : IBaseEFRepository<PrintingEdition>
    {
        Task<IEnumerable<PrintingEditionModelItem>> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels, List<TypePrintingEditionEnum.Type> categories);
    }
}
