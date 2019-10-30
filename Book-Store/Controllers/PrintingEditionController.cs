using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Services.Interfaces;
using BookStore.DataAccess.Models.PrintingEditionsFilterModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
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
            var printingEditionModel = await _printingEditorService.GetPrintingEditionsAsync(printingEditionsFilterModels);
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
                Type = "Book",
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
                Type = "Book",
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
    }
}