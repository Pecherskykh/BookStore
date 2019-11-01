using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Users;
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
        Task<BaseModel> CreateAsync(ApplicationUser user);
        Task<UserModelItem> FindByIdAsync(string userId);
        Task<bool> UpdateAsync(ApplicationUser user);
        Task RemoveAsync(ApplicationUser user);
        Task<UserModel> GetUsersAsync(UsersFilterModel usersFilter);
        Task<BaseModel> ChangeUserStatus(string userId);
    }
}
