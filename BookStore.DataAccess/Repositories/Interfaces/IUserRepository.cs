using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Models.UesrsFilterModel;
using BookStore.DataAccess.Models.Users;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<bool> ConfirmEmailAsync(ApplicationUser user, string token);
        Task<bool> ResetPasswordAsync(ApplicationUser user, string token, string password);
        Task<bool> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
        Task<ApplicationUser> FindByIdAsync(string userId);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<ApplicationUser> FindByNameAsync(string userName);
        Task<bool> CreateAsync(ApplicationUser user, string password);
        Task<bool> UpdateAsync(ApplicationUser user);
        Task<bool> RemoveAsync(ApplicationUser user);
        Task<string> CheckRoleAsync(string userId);
        Task<bool> CheckUserAsync(ApplicationUser user, string password);
        Task SignInAsync(ApplicationUser user);
        Task<UserModel> GetUsersAsync(UsersFilterModel usersFilter);
        Task LogOutAsync();
    }
}
