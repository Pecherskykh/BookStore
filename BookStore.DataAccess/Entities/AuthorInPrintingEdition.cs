using System.ComponentModel.DataAnnotations.Schema;
using BookStore.DataAccess.Entities.Base;

namespace BookStore.DataAccess.Entities
{
    public class AuthorInPrintingEdition : BaseEntity
    {
        [ForeignKey("AuthorId")]
        public long AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("PrintingEditionId")]
        public long PrintingEditionId { get; set; }        
        public PrintingEdition PrintingEdition { get; set; }
    }
}
