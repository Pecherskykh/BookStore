using BookStore.BusinessLogic.Models.Base;
using System.Collections.Generic;
using static BookStore.BusinessLogic.Models.Enums.Enums;

namespace BookStore.BusinessLogic.Models.PrintingEditionsFilterModel
{
    public class PrintingEditionsFilterModel : BaseFilterModel
    {
        public List<TypePrintingEdition> Categories { get; set; }
        public PrintingEditionSortType SortType { get; set; }
        public Currencys Currency { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
