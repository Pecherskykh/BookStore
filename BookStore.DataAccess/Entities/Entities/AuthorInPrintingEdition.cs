using System;
using System.Collections.Generic;
using System.Text;
using BookStore.DataAccess.Entities.Base;

namespace BookStore.DataAccess.Entities.Enums
{
    public class AuthorInPrintingEdition : BaseEntity
    {
        public long AuthorId { get; set; }
        //public Author Author { get; set; }
        public long PrintingEditionId { get; set; }
        //public PrintingEdition PrintingEdition { get; set; }
    }
}
