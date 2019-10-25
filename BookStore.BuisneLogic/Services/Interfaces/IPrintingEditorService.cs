using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEditorService
    {
        Task<PrintingEditionModel> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels);
    }
}
