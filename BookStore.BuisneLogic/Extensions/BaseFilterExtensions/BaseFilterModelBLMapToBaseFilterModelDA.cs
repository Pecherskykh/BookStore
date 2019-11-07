using BookStore.BusinessLogic.Models.Base;

namespace BookStore.BusinessLogic.Extensions.BaseFilterExtensions
{
    public static class BaseFilterModelBLMapToBaseFilterModelDA
    {
        public static DataAccess.Models.Base.BaseFilterModel Map(this BaseFilterModel baseFilterModel)
        {
            return new DataAccess.Models.Base.BaseFilterModel
            {
                PageCount = baseFilterModel.PageCount,
                PageSize = baseFilterModel.PageSize,
                SearchString = baseFilterModel.SearchString,
                SortingDirection = (DataAccess.Models.Enums.Enums.SortingDirection)baseFilterModel.SortingDirection
            };
        }
    }
}