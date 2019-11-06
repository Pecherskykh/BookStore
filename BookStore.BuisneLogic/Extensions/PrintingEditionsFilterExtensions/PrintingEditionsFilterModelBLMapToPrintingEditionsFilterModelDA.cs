using BookStore.BusinessLogic.Models.PrintingEditionsFilterModel;

namespace BookStore.BusinessLogic.Extensions.PrintingEditionsFilterExtensions
{
    public static class PrintingEditionsFilterModelBLMapToPrintingEditionsFilterModelDA
    {
        public static DataAccess.Models.PrintingEditionsFilterModels.PrintingEditionsFilterModel Map(this PrintingEditionsFilterModel printingEditionsFilterModel)
        {
            return new DataAccess.Models.PrintingEditionsFilterModels.PrintingEditionsFilterModel
            {
                PageCount = printingEditionsFilterModel.PageCount,
                PageSize = printingEditionsFilterModel.PageSize,
                Categories = printingEditionsFilterModel.Categories,
                MaxPrice = printingEditionsFilterModel.MaxPrice,
                MinPrice = printingEditionsFilterModel.MinPrice,
                SearchString = printingEditionsFilterModel.SearchString,
                SortType = printingEditionsFilterModel.SortType,
                SortingDirection = printingEditionsFilterModel.SortingDirection
            };
        }
    }
}