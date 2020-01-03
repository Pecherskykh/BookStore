using System.Threading.Tasks;
using BookStore.BusinessLogic.Models.PrintingEditions;
using BookStore.BusinessLogic.Models.PrintingEditionsFilterModel;
using BookStore.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetPrintingEditions(PrintingEditionsFilterModel printingEditionsFilterModels)
        {           
            var printingEditionModel = await _printingEditorService.GetPrintingEditionsAsync(printingEditionsFilterModels);
            return Ok(printingEditionModel);
        }

        [HttpGet("findById")]
        public async Task<IActionResult> FindById(long id)
        {
            var printingEditionModelItem = await _printingEditorService.FindByIdAsync(id);
            return Ok(printingEditionModelItem);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(PrintingEditionModelItem printingEditionsItem)
        {
            var printingEditionModel = await _printingEditorService.CreateAsync(printingEditionsItem);
            return Ok(printingEditionModel);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(PrintingEditionModelItem printingEditionsItem)
        {
            var printingEditionModel = await _printingEditorService.UpdateAsync(printingEditionsItem);
            return Ok(printingEditionModel);
        }

        [HttpPost("remove")]
        public async Task<IActionResult> Remove(PrintingEditionModelItem printingEditionsItem)
        {
            var printingEditionModel = await _printingEditorService.RemoveAsync(printingEditionsItem);
            return Ok(printingEditionModel);
        }
    }
}