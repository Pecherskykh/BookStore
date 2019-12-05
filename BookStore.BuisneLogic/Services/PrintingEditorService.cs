using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Extensions.PrintingEditionExtensions;
using BookStore.BusinessLogic.Extensions.AuthorInPrintingEditionExtensions;
using BookStore.BusinessLogic.Extensions.PrintingEditionsFilterExtensions;
using BookStore.BusinessLogic.Models.PrintingEditionsFilterModel;

namespace BookStore.BusinessLogic.Services
{
    public class PrintingEditorService : IPrintingEditorService
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;

        public PrintingEditorService(IPrintingEditionRepository printingEditionRepository, IAuthorInPrintingEditionRepository authorInPrintingEditionRepository)
        {
            _printingEditionRepository = printingEditionRepository;
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
        }

        public async Task<PrintingEditionModelItem> FindByIdAsync(long printingEditionId)
        {
            var resultModel = new PrintingEditionModelItem();
            if (printingEditionId == 0)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.PrintingEditionIdIsZeroError);
                return resultModel;
            }
            var printingEdition = await _printingEditionRepository.FindByIdAsync(printingEditionId);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.PrintingEditionNotFoundError);
                return resultModel;
            }
            return printingEdition.Map();
        }

        public async Task<BaseModel> CreateAsync(PrintingEditionModelItem printingEdition)
        {
            var resultModel = new BaseModel();
            if (printingEdition == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.PrintingEditionModelItemIsEmptyError);
                return resultModel;
            }
            printingEdition.Id = await _printingEditionRepository.CreateAsync(printingEdition.Map());
            if(printingEdition.Id == 0)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.PrintingEditionNotCreatedError);
                return resultModel;
            }
            foreach (var author in printingEdition.Authors.Items)
            {
                var result = await _authorInPrintingEditionRepository.CreateAsync(printingEdition.Map(author)); //todo check result
                if (result == 0)
                {
                    resultModel.Errors.Add(Constants.ErrorConstants.PrintingEditionNotCreatedError);
                }
            }
            return resultModel;
        }

        public async Task<BaseModel> UpdateAsync(PrintingEditionModelItem printingEdition)
        {
            var resultModel = new BaseModel();
            if (printingEdition == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.PrintingEditionModelItemIsEmptyError);
                return resultModel;
            }
            var result = await _printingEditionRepository.UpdateAsync(printingEdition.Map());
            if (!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.DataNotUpdatedError);
            }
            var authorInPrintingEditions = _authorInPrintingEditionRepository.GetAuthorInPrintingEditionsAsync(printingEdition.Id);
            if (authorInPrintingEditions.Count != printingEdition.Authors.Items.Count)
            {
                await _authorInPrintingEditionRepository.RemoveRangeAsync(authorInPrintingEditions);

                foreach (var author in printingEdition.Authors.Items)
                {
                    var resultCreate = await _authorInPrintingEditionRepository.CreateAsync(printingEdition.Map(author)); //todo check result
                    if (resultCreate == 0)
                    {
                        resultModel.Errors.Add(Constants.ErrorConstants.PrintingEditionNotCreatedError);
                    }
                }
                return resultModel; //todo write errors to this model
            }
            foreach (var author in printingEdition.Authors.Items)
            {
                var resultUpdate = await _authorInPrintingEditionRepository.UpdateAsync(printingEdition.Map(author)); //todo check result
                if (!resultUpdate)
                {
                    resultModel.Errors.Add(Constants.ErrorConstants.DataNotUpdatedError);
                }
            }
            return resultModel;
        }

        public async Task<BaseModel> RemoveAsync(PrintingEditionModelItem printingEdition)
        {
            var resultModel = new BaseModel();
            if (printingEdition == null)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.PrintingEditionModelItemIsEmptyError);
                return resultModel;
            }
            var result = await _printingEditionRepository.IsRemoveAsync(printingEdition.Map());
            if(!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.DataNotRemovedError);
                return resultModel;
            }
            var authorInPrintingEditions = _authorInPrintingEditionRepository.GetAuthorInPrintingEditionsAsync(printingEdition.Id);
            foreach (var authorInPrintingEdition in authorInPrintingEditions)
            {
                await _authorInPrintingEditionRepository.IsRemoveAsync(authorInPrintingEdition);
            }
            return new BaseModel();
        }

        public async Task<PrintingEditionModel> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels)
        {
            var resultModel = (await _printingEditionRepository.GetPrintingEditionsAsync(printingEditionsFilterModels.Map())).Map();
            return resultModel;
        }
    }
}
