using static BookStore.BusinessLogic.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Helpers.Interfaces
{
    public interface IConvertCurrencyHelper
    {
        double ConvertCurrency(double price, Currencys from, Currencys to);
    }
}