using MailSender;
using MailSenderFunction;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using QueueStorage;

[assembly: FunctionsStartup(typeof(Startup))]
namespace MailSenderFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<ISaleService, SaleService>();
            builder.Services.AddScoped<IMailService, MailService>();
            builder.Services.AddScoped<IMailSenderService, SendGridMailService>();

            
        }
    }
}