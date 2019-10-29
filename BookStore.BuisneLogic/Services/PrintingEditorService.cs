using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.BusinessLogic.Extensions;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Entities.Enums;
using BookStore.BusinessLogic.Services.BaseService;
using BookStore.BusinessLogic.Models.Orders;
using BookStore.BusinessLogic.Common.Constants;

namespace BookStore.BusinessLogic.Services
{
    public class PrintingEditorService : BaseService<PrintingEdition, IPrintingEditionRepository>, IPrintingEditorService
    {
        public PrintingEditorService(IPrintingEditionRepository _baseEFRepository) : base(_baseEFRepository)
        {
        }

        public async Task<PrintingEditionModelItem> FindByIdAsync(long printingEditionId)
        {
            var resultModel = new PrintingEditionModelItem();
            var printingEdition = await _baseEFRepository.FindByIdAsync(printingEditionId);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(EmailConstants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            return printingEdition.Mapping();
        }

        public async Task<PrintingEditionModel> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels)
        {
            var printingEditions = await _baseEFRepository.GetPrintingEditionsAsync(printingEditionsFilterModels);
            var resultModel = new PrintingEditionModel();
            foreach (var printingEdition in printingEditions)
            {
                resultModel.Items.Add(printingEdition.Mapping());
            }
            return resultModel;
        }
    }
}
