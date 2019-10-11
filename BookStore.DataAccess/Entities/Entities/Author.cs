using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BookStore.DataAccess.Entities.Base;

namespace BookStore.DataAccess.Entities.Enums
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
    }
}
