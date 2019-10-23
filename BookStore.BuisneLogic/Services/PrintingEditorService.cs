using BookStore.BusinessLogic.Services.Interfaces;
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

        public async Task PrintingEditionsAsync(PrintingEditionsFilterModels printingEditionsFilterModels)
        {
            await _printingEditionRepository.PrintingEditionsAsync(printingEditionsFilterModels);
        }
    }
}
