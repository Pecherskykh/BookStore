using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using BookStore.DataAccess.Entities.Base;

namespace BookStore.DataAccess.Entities.Enums
{
    public class AuthorInPrintingEdition : BaseEntity
    {
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [ForeignKey("PrintingEditionId")]
        public int PrintingEditionId { get; set; }        
        public PrintingEdition PrintingEdition { get; set; }
    }
}
