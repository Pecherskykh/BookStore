using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.UesrsFilterModel;
using BookStore.BusinessLogic.Models.Users;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("find")]
        public async Task<IActionResult> GetByIdAsync(string userId) //todo rename to get
        {
            var user = await _userService.FindByIdAsync(userId);
            return Ok(user);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(UserModelItem user)
        {
            var result = await _userService.CreateAsync(user);
            return Ok(result);
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveAsync(UserModelItem user)
        {
            var result = await _userService.RemoveAsync(user); //todo return BaseModel
            return Ok(result);
        }

        [HttpPost("getUsers")]
        public async Task<IActionResult> GetUsers(UsersFilterModel usersFilter)
        {
            var users = await _userService.GetUsersAsync(usersFilter);
            return Ok(users);
        }

        [HttpPost("changeUserStatus")]
        public async Task<IActionResult> ChangeUserStatus(string userId)
        {
            var resultModel = await _userService.ChangeUserStatus(userId);
            return Ok(resultModel);
        }

        [AllowAnonymous]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(UserModelItem user)
        {
            var role = this.HttpContext.User.Claims
               .FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            var result = await _userService.UpdateAsync(user, role);
            return Ok(result);
        }
    }
}