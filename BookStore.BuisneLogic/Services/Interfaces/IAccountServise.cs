using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Login;
using BookStore.BusinessLogic.Models.Users;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IAccountServise
    {
        Task<UserModelItem> FindByIdAsync(string userId);
        Task<UserModelItem> FindByEmailAsync(string email);
        Task<UserModelItem> FindByNameAsync(string userName);
        Task<BaseModel> Register(UserModelItem user);
        Task<BaseModel> ConfirmEmail(string userId, string token);
        Task<BaseModel> ForgotPassword(string userEmail);
        Task<UserModelItem> CheckUserAsync(LoginModel loginModel);
        Task<string> CheckRoleAsync(UserModelItem user);
        Task LogOutAsync();
    }
}
