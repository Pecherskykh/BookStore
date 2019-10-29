using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    //[Autorize(Role = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /*public async Task<IActionResult> CreateAsync(AuthorModelItem author)
        {
            await _baseEFRepository.CreateAsync(tEntity);
            return new BaseModel();
        }

        public async Task<BaseModel> UpdateAsync(TEntity tEntity)
        {
            await _baseEFRepository.UpdateAsync(tEntity);
            return new BaseModel();
        }

        public async Task<BaseModel> RemoveAsync(TEntity tEntity)
        {
            await _baseEFRepository.RemoveAsync(tEntity);
            return new BaseModel();
        }*/

        [HttpPost("test")]
        public async Task<IActionResult> Test()
        {
            var authorModel = await _authorService.GetAuthorsAsync();
            var a = await _authorService.FindByIdAsync(7);
            await _authorService.Find(a);
            return Ok(authorModel);
        }
    }
}