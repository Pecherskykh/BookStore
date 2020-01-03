using BookStore.DataAccess.Models.Base;
using System.Collections.Generic;
using static BookStore.DataAccess.Entities.Enums.Enums;
using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.DataAccess.Models.PrintingEditionsFilterModels
{
    public class PrintingEditionsFilterModel : BaseFilterModel
    {
        public List<TypePrintingEdition> Categories { get; set; }
        public Currencys Currency { get; set; }
        public PrintingEditionSortType SortType { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
