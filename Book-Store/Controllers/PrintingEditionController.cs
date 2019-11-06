using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.Authors;
using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Models.PrintingEditionsFilterModel;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BookStore.DataAccess.Entities.Enums.Enums;
using static BookStore.DataAccess.Models.Enums.Enums.PrintingEditionsFilterEnums;

namespace BookStore.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //todo add attrs
    public class PrintingEditionController : ControllerBase
    {
        private readonly IPrintingEditorService _printingEditorService;

        public PrintingEditionController(IPrintingEditorService printingEditorService)
        {
            _printingEditorService = printingEditorService;
        }

        [HttpPost("getPrintingEditions")]
        public async Task<IActionResult> GetPrintingEditions(/*PrintingEditionsFilterModel printingEditionsFilterModels*/)
        {
            var printingEditionsFilterModels = new PrintingEditionsFilterModel()
            {
                Categories = new List<TypePrintingEditionEnum.Type>()
                {
                    TypePrintingEditionEnum.Type.Book,
                    TypePrintingEditionEnum.Type.Magazine
                },
                SortType = SortType.Price,
                MinPrice = 20,
                MaxPrice = 100
            };            
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
                ProductType = TypePrintingEditionEnum.Type.Book,
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
                ProductType = TypePrintingEditionEnum.Type.Book,
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
                ProductType = TypePrintingEditionEnum.Type.Book,
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