using AzureServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public interface IMailService
    {
        Task<bool> SendMailAfterSale(Sale model);
    }
}
