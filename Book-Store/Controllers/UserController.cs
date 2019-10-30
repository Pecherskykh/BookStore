using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Extensions;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Models.Users;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using BookStore.DataAccess.Models.UesrsFilterModel;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPrintingEditorService _printingEditorService;

        public UserController(IUserService userService, IPrintingEditorService printingEditorService)
        {
            _userService = userService;
            _printingEditorService = printingEditorService; 
        }

        [HttpPost("find")]
        public async Task<IActionResult> FindByIdAsync(string userId)
        {
            var user = await _userService.FindByIdAsync(userId);
            return Ok(user);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(UserModelItem user)
        {
            await _userService.UpdateAsync(user.Mapping());
            return Ok(new BaseModel());
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveAsync(UserModelItem user)
        {
            await _userService.RemoveAsync(user.Mapping());
            return Ok(new BaseModel());
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test(UsersFilterModel usersFilter)
        {
            var users = await _userService.GetUsersAsync(usersFilter);
            return Ok(users);
        }
        
        public async Task<IActionResult> ChangeUserStatus(string userId)
        {
            var resultModel = new BaseModel();
            resultModel = await _userService.ChangeUserStatus(userId);
            return Ok(resultModel);
        }       
    }
}