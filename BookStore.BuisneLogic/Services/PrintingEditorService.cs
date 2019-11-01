﻿using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.BusinessLogic.Extensions;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using BookStore.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookStore.DataAccess.Entities.Enums;
using BookStore.BusinessLogic.Models.Orders;
using BookStore.BusinessLogic.Common.Constants;
using BookStore.BusinessLogic.Models.Base;
using System.Linq;
using static BookStore.DataAccess.Entities.Enums.Enums;

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
            var printingEdition = await _printingEditionRepository.FindByIdAsync(printingEditionId);
            if (printingEdition == null)
            {
                resultModel.Errors.Add(EmailConstants.ErrorConstants.UserNotFoundError);
                return resultModel;
            }
            return printingEdition.Mapping();
        }

        public async Task<long> CreateAsync(PrintingEditionModelItem printingEdition)
        {

            printingEdition.Id = await _printingEditionRepository.CreateAsync(printingEdition.Mapping());

            foreach (var author in printingEdition.Authors.Items)
            {
                await _authorInPrintingEditionRepository.CreateAsync(printingEdition.Mapping(author));
            }
            return printingEdition.Id;
        }

        public async Task<BaseModel> UpdateAsync(PrintingEditionModelItem printingEdition)
        {
            await _printingEditionRepository.UpdateAsync(printingEdition.Mapping());
            var authorInPrintingEditions = await _authorInPrintingEditionRepository.GetAuthorInPrintingEditionsAsync(printingEdition.Id);
            await _authorInPrintingEditionRepository.RemoveRangeAsync(authorInPrintingEditions);

            foreach (var author in printingEdition.Authors.Items)
            {
                await _authorInPrintingEditionRepository.CreateAsync(printingEdition.Mapping(author));
            }
            return new BaseModel();
        }

        public async Task<BaseModel> RemoveAsync(PrintingEditionModelItem printingEdition)
        {
            printingEdition.IsRemoved = true;
            await _printingEditionRepository.UpdateAsync(printingEdition.Mapping());
            var authorInPrintingEditions = (await _authorInPrintingEditionRepository.GetAuthorInPrintingEditionsAsync(printingEdition.Id)).ToList();
            foreach (var authorInPrintingEdition in authorInPrintingEditions)
            {
                authorInPrintingEdition.IsRemoved = true;
                await _authorInPrintingEditionRepository.UpdateAsync(authorInPrintingEdition);
            }
            return new BaseModel();
        }

        public async Task<PrintingEditionModel> GetPrintingEditionsAsync(PrintingEditionsFilterModel printingEditionsFilterModels, List<TypePrintingEditionEnum.Type> categories)
        {
            var printingEditions = await _printingEditionRepository.GetPrintingEditionsAsync(printingEditionsFilterModels, categories);
            var resultModel = new PrintingEditionModel();
            foreach (var printingEdition in printingEditions)
            {
                resultModel.Items.Add(printingEdition.Mapping());
            }
            return resultModel;
        }
    }
}
