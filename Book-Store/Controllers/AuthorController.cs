using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorEditorService;

        public AuthorController(IAuthorService authorEditorService)
        {
            _authorEditorService = authorEditorService;
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test()
        {
            var authorModel = await _authorEditorService.GetAuthorsAsync();
            return Ok(authorModel);
        }
    }
}