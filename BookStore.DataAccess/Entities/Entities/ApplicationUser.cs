using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DataAccess.Entities.Enums
{
    public class ApplicationUser : IdentityUser<long>
    {
        public bool IsRemoved { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
