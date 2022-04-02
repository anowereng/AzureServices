
using AutoWrapper.Wrappers;
using AzureServices.Models;

namespace QueueStorage
{
    public interface ISaleService
    {
        Task<ApiResponse> AddAsync(Sale model);
        Task SendMail();
    }
}