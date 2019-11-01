using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookStore.DataAccess.Entities.Enums.Enums.CurrencyEnum;

namespace BookStore.BusinessLogic.Helpers
{
    public class ConvertCurrencyHelper
    {
        public async Task<double> ConvertCurrency(double price, Currencys from, Currencys to)
        {
            /*Dictionary<Currencys, double> keyValuePairs = new keyValuePairs()
            {

            }*/
            return ConvertUsd(ConvertToUsd(price, from), to);
        }

        private double ConvertToUsd(double price, Currencys currencys)
        {
            var allCategories = (Enum.GetValues(typeof(Currencys))).OfType<Currencys>().ToList();

            if (currencys == Currencys.AUD)
            {
                return price / 1.47;
            }
            if (currencys == Currencys.BYN)
            {
                return price / 2.05;
            }
            if (currencys == Currencys.EUR)
            {
                return price / 0.9;
            }
            if (currencys == Currencys.GBP)
            {
                return price / 0.78;
            }
            if (currencys == Currencys.PLN)
            {
                return price / 3.86;
            }
            if (currencys == Currencys.UAH)
            {
                return price / 25.16;
            }
            return price;
        }

        private double ConvertUsd(double priceUsd, Currencys currencys)
        {
            if (currencys == Currencys.AUD)
            {
                return priceUsd * 1.47;
            }
            if (currencys == Currencys.BYN)
            {
                return priceUsd * 2.05;
            }
            if (currencys == Currencys.EUR)
            {
                return priceUsd * 0.9;
            }
            if (currencys == Currencys.GBP)
            {
                return priceUsd * 0.78;
            }
            if (currencys == Currencys.PLN)
            {
                return priceUsd * 3.86;
            }
            if (currencys == Currencys.UAH)
            {
                return priceUsd * 25.16;
            }
            return priceUsd;
        }
    }
}
