using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.UesrsFilterModel;
using BookStore.BusinessLogic.Models.Users;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<BaseModel> CreateAsync(UserModelItem user);
        Task<UserModelItem> FindByIdAsync(string userId);
        Task<BaseModel> UpdateAsync(UserModelItem user, string role);
        Task<BaseModel> RemoveAsync(UserModelItem user);
        Task<UserModel> GetUsersAsync(UsersFilterModel usersFilter);
        Task<BaseModel> ChangeUserStatus(string userId);
        void DapperTest();
    }
}
