using BookStore.DataAccess.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;
using static BookStore.DataAccess.Models.Enums.Enums.PrintingEditionsFilterEnums;

namespace BookStore.DataAccess.Models.PrintingEditionsFilterModels
{
    public class PrintingEditionsFilterModel : BaseModel
    {
        public SortingDirection SortingDirection { get; set; }
        public SortBy SortBy { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
