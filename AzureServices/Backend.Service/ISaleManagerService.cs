using AutoWrapper.Wrappers;
using AzureServices.Models;

namespace Backend.Service
{
    public interface ISaleManagerService
    {
        Sale Add(Sale model);
    }
}