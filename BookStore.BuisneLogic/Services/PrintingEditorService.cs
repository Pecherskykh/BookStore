using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.BusinessLogic.Extensions;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    public class PrintingEditorService : IPrintingEditorService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;

        public PrintingEditorService(IPrintingEditionRepository printingEditionRepository)
        {
            _printingEditionRepository = printingEditionRepository;
        }

        public async Task<PrintingEditionModel> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels)
        {
            var printingEditions = await _printingEditionRepository.GetPrintingEditionsAsync(printingEditionsFilterModels);
            var resultModel = new PrintingEditionModel();
            foreach (var printingEdition in printingEditions)
            {
                resultModel.Items.Add(printingEdition.Mapping());
            }
            return resultModel;
        }
    }
}
