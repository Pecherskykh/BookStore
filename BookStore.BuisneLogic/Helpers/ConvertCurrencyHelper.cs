using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static BookStore.BusinessLogic.Models.Enums.Enums.CurrencyEnums;

namespace BookStore.BusinessLogic.Helpers
{
    public class ConvertCurrencyHelper
    {
        public async Task<double> ConvertCurrency(double priceInUsd, Currencys currencys)
        {            
            if (currencys == Currencys.AUD)
            {
                return priceInUsd * 1.47;
            }
            if (currencys == Currencys.BYN)
            {
                return priceInUsd * 2.05;
            }
            if (currencys == Currencys.EUR)
            {
                return priceInUsd * 0.9;
            }
            if (currencys == Currencys.GBP)
            {
                return priceInUsd * 0.78;
            }
            if (currencys == Currencys.PLN)
            {
                return priceInUsd * 3.86;
            }
            if (currencys == Currencys.UAH)
            {
                return priceInUsd * 25.16;
            }
            return priceInUsd;
        }
    }
}
