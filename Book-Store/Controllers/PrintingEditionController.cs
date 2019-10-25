using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}