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
using BookStore.BusinessLogic.Helpers.Interfaces;
using static BookStore.BusinessLogic.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Services
{
    public class PrintingEditorService : IPrintingEditorService //todo rename
    {
        private readonly IPrintingEditionRepository _printingEditionRepository;
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEditionRepository;
        private readonly IConvertCurrencyHelper _convertCurrencyHelper;

        public PrintingEditorService(IPrintingEditionRepository printingEditionRepository, IAuthorInPrintingEditionRepository authorInPrintingEditionRepository, IConvertCurrencyHelper convertCurrencyHelper)
        {
            _printingEditionRepository = printingEditionRepository;
            _authorInPrintingEditionRepository = authorInPrintingEditionRepository;
            _convertCurrencyHelper = convertCurrencyHelper;
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

            CheckPrintingEditionErrors(printingEdition, resultModel);

            if (resultModel.Errors.Count > 0)
            {
                return resultModel;
            }

            printingEdition.Price = (decimal)_convertCurrencyHelper.ConvertCurrency((double)printingEdition.Price, printingEdition.Currencys, Currencys.USD);
            printingEdition.Id = await _printingEditionRepository.CreateAsync(printingEdition.Map());
            if(printingEdition.Id == 0)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.PrintingEditionNotCreatedError);
                return resultModel;
            }
            if (printingEdition.Authors.Items == null)
            {
                return resultModel;
            }
            if (printingEdition.Authors.Items == null)
            {
                return resultModel;
            }
            foreach (var author in printingEdition.Authors.Items)
            {
                var result = await _authorInPrintingEditionRepository.CreateAsync(printingEdition.Map(author));
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

            CheckPrintingEditionErrors(printingEdition, resultModel);

            if (resultModel.Errors.Count > 0)
            {
                return resultModel;
            }

            var result = await _printingEditionRepository.UpdateAsync(printingEdition.Map());
            if (!result)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.DataNotUpdatedError);
            }
            var authorInPrintingEditions = _authorInPrintingEditionRepository.GetAuthorInPrintingEditionsAsync(printingEdition.Id);
            if (authorInPrintingEditions.Count != printingEdition.Authors.Items.Count) //todo if if, use private methods if need
            {
                await _authorInPrintingEditionRepository.RemoveRangeAsync(authorInPrintingEditions);

                foreach (var author in printingEdition.Authors.Items)
                {
                    var resultCreate = await _authorInPrintingEditionRepository.CreateAsync(printingEdition.Map(author));
                    if (resultCreate == 0)
                    {
                        resultModel.Errors.Add(Constants.ErrorConstants.PrintingEditionNotCreatedError);
                    }
                }
                return resultModel;
            }
            var count = 0;
            foreach (var author in printingEdition.Authors.Items)
            {
                authorInPrintingEditions[count].AuthorId = author.Id;
                var resultUpdate = await _authorInPrintingEditionRepository.UpdateAsync(authorInPrintingEditions[count]);
                if (!resultUpdate)
                {
                    resultModel.Errors.Add(Constants.ErrorConstants.DataNotUpdatedError);
                }
                ++count;
            }
            return resultModel;
        }

        private void CheckPrintingEditionErrors(PrintingEditionModelItem printingEdition, BaseModel resultModel)
        {
            if (string.IsNullOrWhiteSpace(printingEdition.Title))
            {
                resultModel.Errors.Add(Constants.ErrorConstants.NoTitle);
            }

            if (printingEdition.ProductType == 0)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.ProductTypeNotAssigned);
            }

            if (printingEdition.Currencys == 0)
            {
                resultModel.Errors.Add(Constants.ErrorConstants.NoCurrencyAssigned);
            }
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
            printingEditionsFilterModels.MinPrice = (decimal)_convertCurrencyHelper.ConvertCurrency((double)printingEditionsFilterModels.MinPrice,
                printingEditionsFilterModels.Currency, Currencys.USD);

            printingEditionsFilterModels.MaxPrice = (decimal)_convertCurrencyHelper.ConvertCurrency((double)printingEditionsFilterModels.MaxPrice,
                printingEditionsFilterModels.Currency, Currencys.USD);

            var resultModel = (await _printingEditionRepository.GetPrintingEditionsAsync(printingEditionsFilterModels.Map())).Map();
            foreach(var item in resultModel.Items)
            {
                item.Price = (decimal)_convertCurrencyHelper.ConvertCurrency((double)item.Price, Currencys.USD, printingEditionsFilterModels.Currency);
            }
            return resultModel;
        }
    }
}
