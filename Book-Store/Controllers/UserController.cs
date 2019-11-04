using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Users;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Models.UesrsFilterModel;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //todo attrs
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("find")]
        public async Task<IActionResult> FindByIdAsync(string userId) //todo rename to get
        {
            var user = await _userService.FindByIdAsync(userId);
            return Ok(user);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(UserModelItem user)
        {
            await _userService.UpdateAsync(user); //todo return BaseModel
            return Ok(new BaseModel());
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
            await _userService.RemoveAsync(user); //todo return BaseModel
            return Ok(new BaseModel());
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test(UsersFilterModel usersFilter)
        {
            var users = await _userService.GetUsersAsync(usersFilter);
            return Ok(users);
        }

        //todo add attrs   
        public async Task<IActionResult> ChangeUserStatus(string userId)
        {
            var resultModel = await _userService.ChangeUserStatus(userId);
            return Ok(resultModel);
        }       
    }
}