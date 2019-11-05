using BookStore.BusinessLogic.Models.Base;

namespace BookStore.BusinessLogic.Models.Users
{
    public class UserModelItem : BaseModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
