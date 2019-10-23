using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using BookStore.DataAccess.Models.UesrsFilterModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateAsync(ApplicationUser user);
        Task<ApplicationUser> GetAsync(string userId);
        Task<Role> RoleCheckAsync(long userId);
        Task AddRoleAsync(long userId, string role);
        Task<bool> UpdateAsync(ApplicationUser user);
        Task RemoveAsync(ApplicationUser user);
        Task<IEnumerable<ApplicationUser>> GetUsersAsync(UsersFilter usersFilter);
        Task BlockAndUnblockUser(string userId);
    }
}
