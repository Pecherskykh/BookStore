using BookStore.DataAccess.Entities;
using BookStore.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateAsync(ApplicationUser user);
        Task<Role> RoleCheckAsync(long userId);
        Task AddRoleAsync(long userId, string role);
        Task<bool> UpdateAsync(ApplicationUser user);
        Task RemoveAsync(ApplicationUser user);
    }
}
