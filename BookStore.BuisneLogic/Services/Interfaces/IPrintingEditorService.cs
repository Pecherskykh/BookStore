using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IPrintingEditorService : IBaseService<PrintingEditionModelItem>
    {
        Task<PrintingEditionModel> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels);
    }
}
