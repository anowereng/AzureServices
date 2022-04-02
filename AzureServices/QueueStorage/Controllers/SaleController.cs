using AzureServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueueStorage;
using System.Text.Json;

namespace AzurePaas.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post(Sale model)
        {
            try
            {
                await _saleService.AddAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("SendMail")]
        public async Task<IActionResult> SendMail()
        {
            try
            {
                await _saleService.SendMail();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
