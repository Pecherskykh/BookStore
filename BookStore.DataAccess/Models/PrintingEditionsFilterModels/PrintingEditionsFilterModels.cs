using BookStore.DataAccess.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static BookStore.DataAccess.Models.Enums.PrintingEditionsFilterEnums;
using static BookStore.DataAccess.Models.PrintingEditionsFilterModels.Enums.PrintingEditionsFilterEnums;

namespace BookStore.DataAccess.Models.PrintingEditionsFilterModels
{
    public class PrintingEditionsFilterModels : BaseModel
    {
        public Sorted Sorted { get; set; }
        public SortBy SortBy { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
