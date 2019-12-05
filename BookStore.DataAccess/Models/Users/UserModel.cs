using BookStore.DataAccess.Entities;
using System.Collections.Generic;

namespace BookStore.DataAccess.Models.Users
{
    public class UserModel
    {
        public long Count { get; set; }
        public ICollection<ApplicationUser> Items { get; set; }
    }
}
