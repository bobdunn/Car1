using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Car1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ICsvService _csvService;

        public UploadController(ICsvService csvService)
        {
            _csvService = csvService;
        }
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var csvText = await reader.ReadToEndAsync();
                await _csvService.ProcessCsv(csvText);
            }

            return new StatusCodeResult(StatusCodes.Status202Accepted);
        }
    }
}
