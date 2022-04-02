using AutoWrapper.Wrappers;
using AzureServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service
{
    public class SaleManagerService : ISaleManagerService
    {
        public Sale Add(Sale model)
        {
            // after save backend result ; 
            var result = new Sale
            {
                Id = Guid.NewGuid().ToString(),
                OrderNumber = $"O-{Guid.NewGuid().ToString()}",
                CustomerName = model.CustomerName,
                CustomerPhone = model.CustomerPhone,
                OrderDate = model.OrderDate,
                CustomerEmail = model.CustomerEmail
            };
            return result;
        }
    }
}
