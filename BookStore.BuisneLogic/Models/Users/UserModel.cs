using BookStore.BusinessLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogic.Models.Users
{
    public class UserModel : BaseModel
    {        
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime lockoutEnd { get; set; }
        public bool lockoutEnabled { get; set; }
        public long AccessFiledCount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
