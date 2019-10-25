using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static BookStore.BusinessLogic.Models.Enums.Enums.CurrencyEnums;

namespace BookStore.BusinessLogic.Helpers
{
    public class ConvertCurrencyHelper
    {
        public async Task<double> ConvertCurrency(double from, double to, Currencys currencys)
        {
            if(currencys == Currencys.USD)
            {
                return from;
            }
            if (currencys == Currencys.UAH)
            {
                return from * 25.16;
            }
            if (currencys == Currencys.AUD)
            {
                return from * 0.682695;
            }
            if (currencys == Currencys.BYN)
            {
                return from * 2.0428;
            }
            if (currencys == Currencys.EUR)
            {
                return from * 1.10895;
            }
            return 0;
        }
    }
}
