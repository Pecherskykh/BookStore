using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using Microsoft.AspNetCore.Mvc;
using static BookStore.DataAccess.Entities.Enums.Enums;

namespace BookStore.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrintingEditionController : ControllerBase
    {
        private readonly IPrintingEditorService _printingEditorService;

        public PrintingEditionController(IPrintingEditorService printingEditorService)
        {
            _printingEditorService = printingEditorService;
        }

        [HttpPost("test")]
        public async Task<IActionResult> Test(PrintingEditionsFilterModel printingEditionsFilterModels)
        {
            var categories = new List<TypePrintingEditionEnum.Type>()
            {
                TypePrintingEditionEnum.Type.Books,
                TypePrintingEditionEnum.Type.Magzines
            };            
            var printingEditionModel = await _printingEditorService.GetPrintingEditionsAsync(printingEditionsFilterModels, categories);
            return Ok(printingEditionModel);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(/*PrintingEditionModelItem printingEditionsItem*/)
        {
            var printingEditionsItem = new PrintingEditionModelItem()
            {
                Title = "New Title",
                Description = "New Description",
                Price = 1000,
                Type = TypePrintingEditionEnum.Type.Books,
                Authors = new AuthorModel()
                {
                    Items = new List<AuthorModelItem>()
                    {
                        new AuthorModelItem() { Id = 3 },
                        new AuthorModelItem() { Id = 6 },
                        new AuthorModelItem() { Id = 7 }
                    }
                }
            };
            var printingEditionModel = await _printingEditorService.CreateAsync(printingEditionsItem);
            return Ok(printingEditionModel);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(/*PrintingEditionModelItem printingEditionsItem*/)
        {
            var printingEditionsItem = new PrintingEditionModelItem()
            {
                Id = 13,
                Title = "New TitleUpdate",
                Description = "New Description",
                Price = 1000,
                Type = TypePrintingEditionEnum.Type.Books,
                Authors = new AuthorModel()
                {
                    Items = new List<AuthorModelItem>()
                    {
                        new AuthorModelItem() { Id = 3 },
                        new AuthorModelItem() { Id = 6 },
                    }
                }
            };
            var printingEditionModel = await _printingEditorService.UpdateAsync(printingEditionsItem);
            return Ok(printingEditionModel);
        }

        [HttpPost("remove")]
        public async Task<IActionResult> Remove(/*PrintingEditionModelItem printingEditionsItem*/)
        {
            var printingEditionsItem = new PrintingEditionModelItem()
            {
                Id = 13,
                Title = "New TitleUpdate",
                Description = "New Description",
                Price = 1000,
                Type = TypePrintingEditionEnum.Type.Books,
                Authors = new AuthorModel()
                {
                    Items = new List<AuthorModelItem>()
                    {
                        new AuthorModelItem() { Id = 3 },
                        new AuthorModelItem() { Id = 6 },
                    }
                }
            };
            var printingEditionModel = await _printingEditorService.RemoveAsync(printingEditionsItem);
            return Ok(printingEditionModel);
        }
    }
}