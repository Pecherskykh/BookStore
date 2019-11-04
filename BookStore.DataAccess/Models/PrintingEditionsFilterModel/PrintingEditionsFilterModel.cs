using BookStore.DataAccess.Models.Base;
using static BookStore.DataAccess.Models.Enums.Enums;
using static BookStore.DataAccess.Models.Enums.Enums.PrintingEditionsFilterEnums;

namespace BookStore.DataAccess.Models.PrintingEditionsFilterModels
{
    public class PrintingEditionsFilterModel : BaseModel
    {
        public SortingDirection SortingDirection { get; set; }
        public SortType SortType { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
