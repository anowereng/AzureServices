using System;
using System.Text.Json;
using System.Threading.Tasks;
using AzureServices.Models;
using Azure.Storage.Queues;
using MailSender;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using QueueStorage;

namespace MailSenderFunction
{
    public class Function1
    {
        private readonly IMailService _mailService;
        public Function1(IMailService mailService)
        {
            _mailService = mailService;
        }

        [FunctionName("Function1")]
        public async Task RunAsync([QueueTrigger("upload-file", Connection = "QueueConnection")]string myQueueItem, ILogger log)
        {
            await SendMail(myQueueItem);
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            
        }

        public async Task SendMail(string data)
        {
            var messagedata = JsonSerializer.Deserialize<Sale>(data);
            var result = await _mailService.SendMailAfterSale(messagedata);
        }

    }
}
