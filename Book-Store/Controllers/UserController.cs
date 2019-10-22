using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        UserController(IUserService userService)
        {
            _userService = userService;
        }

        
    }
}