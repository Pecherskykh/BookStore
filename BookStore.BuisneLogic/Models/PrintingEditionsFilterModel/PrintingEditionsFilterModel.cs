using BookStore.BusinessLogic.Models.Base;
using System.Collections.Generic;
using static BookStore.DataAccess.Entities.Enums.Enums;
using static BookStore.DataAccess.Models.Enums.Enums.PrintingEditionsFilterEnums;

namespace BookStore.BusinessLogic.Models.PrintingEditionsFilterModel
{
    public class PrintingEditionsFilterModel : BaseFilterModel
    {
        public List<TypePrintingEditionEnum.Type> Categories { get; set; }
        public SortType SortType { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
