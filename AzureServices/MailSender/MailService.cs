using AzureServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public class MailService : IMailService
    {
        private IMailSenderService _senderService;
        public MailService(IMailSenderService senderService)
        {
            _senderService = senderService;
        }
        public async Task<bool> SendMailAfterSale(Sale model)
        {
            // this content from DB 
            string subject = $"Successfully Place Order , Order number : ({model.OrderNumber})";
            string content = $"Hello {model.CustomerName},  Thanks for purchaseing !. For any query please contact 01822339363";
            await _senderService.SendAsync(model.CustomerEmail, subject, content);
            return true;
        }
    }
}

