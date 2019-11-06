using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Models.PrintingEditionsFilterModel;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEditorService : IBaseService<PrintingEditionModelItem>
    {
        Task<PrintingEditionModel> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels);
    }
}
