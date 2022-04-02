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

        //[Route("GetUploadImage")]
        //[HttpGet]
        //public async Task<IActionResult> GetUploadImage(string fileName)
        //{
        //    var imgBytes = await _fileService.Get(fileName);
        //    return File(imgBytes, "image/webp");
        //}

        //[Route("Download")]
        //[HttpGet]
        //public async Task<IActionResult> Download(string fileName)
        //{
        //    var imagBytes = await _fileService.Get(fileName);
        //    return new FileContentResult(imagBytes, "application/octet-stream")
        //    {
        //        FileDownloadName = Guid.NewGuid().ToString() + ".webp",
        //    };
        //}

        //[Route("Delete")]
        //[HttpGet]
        //public async Task<IActionResult> Delete(string fileName)
        //{
        //    var result = await _fileService.Delete(fileName);
        //    return Ok(result);   
        //}

        //[Route("AzureQueue")]
        //[HttpPost]

        //public async Task<IActionResult> Post(UploadFile model)
        //{
        //    var connectionQueue = "DefaultEndpointsProtocol=https;AccountName=filestorage2022;AccountKey=j9/e2zF6RHXaDPZJ2KGQ9r94RHu8sviug3CVGWGikc/SDrJtilVO5+gVtDlKR/vv54oy1l4JFrp9ralrsfiddw==;EndpointSuffix=core.windows.net";
        //    var queueName = "upload-file";
        //    var queueClient = new QueueClient(connectionQueue, queueName);
        //    var message =  JsonSerializer.Serialize(model);
        //    await queueClient.SendMessageAsync(message);
        //    return Ok();
        //}
    }
}
