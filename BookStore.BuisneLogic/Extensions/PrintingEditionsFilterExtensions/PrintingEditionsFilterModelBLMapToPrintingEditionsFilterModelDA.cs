using BookStore.BusinessLogic.Models.PrintingEditionsFilterModel;
using System.Collections.Generic;

namespace BookStore.BusinessLogic.Extensions.PrintingEditionsFilterExtensions
{
    public static class PrintingEditionsFilterModelBLMapToPrintingEditionsFilterModelDA
    {
        public static DataAccess.Models.PrintingEditionsFilterModels.PrintingEditionsFilterModel Map(this PrintingEditionsFilterModel printingEditionsFilterModel)
        {
            var categories = new List<DataAccess.Entities.Enums.Enums.TypePrintingEdition>();
            foreach(var category in printingEditionsFilterModel.Categories)
            {
                categories.Add((DataAccess.Entities.Enums.Enums.TypePrintingEdition)category);
            }
            return new DataAccess.Models.PrintingEditionsFilterModels.PrintingEditionsFilterModel
            {
                PageCount = printingEditionsFilterModel.PageCount,
                PageSize = printingEditionsFilterModel.PageSize,
                Categories = categories,
                MaxPrice = printingEditionsFilterModel.MaxPrice,
                MinPrice = printingEditionsFilterModel.MinPrice,
                SearchString = printingEditionsFilterModel.SearchString,
                SortType = (DataAccess.Models.Enums.Enums.PrintingEditionSortType)printingEditionsFilterModel.SortType,
                SortingDirection = (DataAccess.Models.Enums.Enums.SortingDirection)printingEditionsFilterModel.SortingDirection,
                Currency = (DataAccess.Entities.Enums.Enums.Currencys)printingEditionsFilterModel.Currency
            };
        }
    }
}