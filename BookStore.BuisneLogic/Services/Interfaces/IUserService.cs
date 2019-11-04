using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Users;
using BookStore.DataAccess.Models.UesrsFilterModel;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseModel> CreateAsync(UserModelItem user);
        Task<UserModelItem> FindByIdAsync(string userId);
        Task<bool> UpdateAsync(UserModelItem user);
        Task<bool> RemoveAsync(UserModelItem user);
        Task<UserModel> GetUsersAsync(UsersFilterModel usersFilter);
        Task<BaseModel> ChangeUserStatus(string userId);
    }
}
