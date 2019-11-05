using BookStore.BusinessLogic.Helpers.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BookStore.DataAccess.Entities.Enums.Enums.CurrencyEnum;

namespace BookStore.BusinessLogic.Helpers
{
    public class ConvertCurrencyHelper : IConvertCurrencyHelper
    {
        private readonly Dictionary<Currencys, double> currencyPrice = new Dictionary<Currencys, double>()
            {
                { Currencys.AUD, 1.47 },
                { Currencys.BYN, 2.05 },
                { Currencys.EUR, 0.9 },
                { Currencys.GBP, 0.78 },
                { Currencys.PLN, 3.86 },
                { Currencys.UAH, 25.16},
                { Currencys.USD, 1}
            };
        public double ConvertCurrency(double price, Currencys from, Currencys to)
        {
            return price / currencyPrice[from] * currencyPrice[to];
        }
    }
}
