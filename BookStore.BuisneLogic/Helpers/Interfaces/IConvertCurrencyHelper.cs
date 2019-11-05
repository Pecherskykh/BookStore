using static BookStore.DataAccess.Entities.Enums.Enums.CurrencyEnum;

namespace BookStore.BusinessLogic.Helpers.Interfaces
{
    public interface IConvertCurrencyHelper
    {
        double ConvertCurrency(double price, Currencys from, Currencys to);
    }
}