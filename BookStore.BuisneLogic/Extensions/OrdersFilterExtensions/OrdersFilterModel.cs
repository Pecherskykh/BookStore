using BookStore.BusinessLogic.Models.OrdersFilterModel;

namespace BookStore.BusinessLogic.Extensions.OrdersFilterExtensions
{
    public static class OrdersFilterModelBLMapToOrdersFilterModelDA
    {
        public static DataAccess.Models.OrdersFilterModel.OrdersFilterModel Map(this OrdersFilterModel ordersFilterModel)
        {
            return new DataAccess.Models.OrdersFilterModel.OrdersFilterModel
            {
                PageCount = ordersFilterModel.PageCount,
                PageSize = ordersFilterModel.PageSize,
                OrderStatus = ordersFilterModel.OrderStatus,
                SearchString = ordersFilterModel.SearchString,
                SortType = ordersFilterModel.SortType,
                SortingDirection = ordersFilterModel.SortingDirection
            };
        }
    }
}