using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using BookStore.DataAccess.Models.UesrsFilterModel;
using Microsoft.AspNetCore.Mvc;
using static BookStore.DataAccess.Models.UesrsFilterModel.Enums.UesrsFilterEnums;

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

        [HttpGet("test")]
        public async Task Test(/*Model*/)
        {
            var usersFilter = new UsersFilter //use Postman
            {
                PageCount = 1,
                PageSize = 10,
                Sorted = Sorted.Email,
                UserActive = UserActive.All
            };
            var users = await _userService.GetUsersAsync(usersFilter);
        }

        [HttpPost("test1")]
        public async Task<IActionResult> Test1(PrintingEditionsFilterModels printingEditionsFilterModels)
        {
            /*var printingEditionsFilterModels = new PrintingEditionsFilterModels
            {
                PageCount = 1,
                PageSize = 10,
                Sorted = DataAccess.Models.PrintingEditionsFilterModels.Enums.PrintingEditionsFilterEnums.Sorted.LowToHigh,
                MinPrice = 10,
                MaxPrice = 30
            };*/
            await _printingEditorService.PrintingEditionsAsync(printingEditionsFilterModels);
            return Ok(printingEditionsFilterModels);
        }

        public async Task<IActionResult> BlockAndUnblockUser(string userId)
        {            
            await _userService.BlockAndUnblockUser(userId);
            return Ok(new BaseModel());
        }       
    }
}