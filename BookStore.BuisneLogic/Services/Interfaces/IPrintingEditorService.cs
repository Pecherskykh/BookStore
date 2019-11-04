using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BookStore.DataAccess.Entities.Enums.Enums;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEditorService : IBaseService<PrintingEditionModelItem>
    {
        Task<PrintingEditionModel> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels, List<TypePrintingEditionEnum.Type> categories);
    }
}
