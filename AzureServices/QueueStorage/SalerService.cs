using AutoWrapper.Wrappers;
using AzureServices.Models;
using Azure.Storage.Queues;
using Backend.Service;
using MailSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QueueStorage
{
    public class SaleService : ISaleService
    {
        private ISaleManagerService _saleService;
        private readonly QueueClient _queueClient;
        private readonly IMailService _mailService;
        public SaleService(ISaleManagerService saleService, QueueClient queueClient, IMailService mailService)
        {
            _saleService = saleService;
            _queueClient = queueClient;
            _mailService = mailService;
        }
        public async Task<ApiResponse> AddAsync(Sale model)
        {
            // 1. db save and get result from sale service 
            var data = _saleService.Add(model);

            // 2. queue add 
            var jsonData = JsonSerializer.Serialize(data);
            await _queueClient.SendMessageAsync(jsonData);

            return new ApiResponse { Message = "Save Success!", Result = data, StatusCode = (int)HttpStatusCode.OK };
        }

        public async Task SendMail()
        {
            var message = await _queueClient.ReceiveMessageAsync();

            if (message.Value != null)
            {
                var messagedata = JsonSerializer.Deserialize<Sale>(message.Value.MessageText);

                var result  = await _mailService.SendMailAfterSale(messagedata);
                if(result)
                    await _queueClient.DeleteMessageAsync(message.Value.MessageId, message.Value.PopReceipt);
            }
            await Task.Delay(TimeSpan.FromSeconds(5));
        }

        

    }
}
