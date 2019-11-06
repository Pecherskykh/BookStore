using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using static BookStore.DataAccess.Entities.Enums.Enums;

namespace BookStore.BusinessLogic.Models.PrintingEditions
{
    public class PrintingEditionModelItem : BaseModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public TypePrintingEditionEnum.Type ProductType { get; set; }
        public AuthorModel Authors { get; set; }
    }
}
