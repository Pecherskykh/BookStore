using Microsoft.AspNetCore.Identity;

namespace BookStore.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public bool IsRemoved { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
    }
}
