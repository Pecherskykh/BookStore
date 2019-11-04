using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BookStore.DataAccess.Models.Enums.Enums;

namespace BookStore.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("find")]
        public async Task<IActionResult> FindByIdAsync(long authorId)
        {
            var author = await _authorService.FindByIdAsync(authorId);
            return Ok(author);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(AuthorModelItem author)
        {
            await _authorService.CreateAsync(author);
            return Ok(new BaseModel());
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(AuthorModelItem author)
        {
            await _authorService.UpdateAsync(author);
            return Ok(new BaseModel());
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveAsync(AuthorModelItem author)
        {
            await _authorService.RemoveAsync(author);
            return Ok(new BaseModel());
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test(SortingDirection sortingDirection)
        {
            var authorModel = await _authorService.GetAuthorsAsync(sortingDirection);
            return Ok(authorModel);
        }
    }
}