using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.Base;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    //todo add attrs
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
            var result = await _authorService.CreateAsync(author); //todo return BaseModel
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(AuthorModelItem author)
        {
            var result = await _authorService.UpdateAsync(author);
            return Ok(result);
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveAsync(AuthorModelItem author)
        {
            var result = await _authorService.RemoveAsync(author);
            return Ok(result);
        }

        [HttpPost("getAuthor")]
        public async Task<IActionResult> GetAuthor(BaseFilterModel baseFilterModel)
        {
            var authorModel = await _authorService.GetAuthorsAsync(baseFilterModel);
            return Ok(authorModel);
        }
    }
}