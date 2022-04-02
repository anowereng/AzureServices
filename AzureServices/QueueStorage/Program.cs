
using Azure.Storage.Queues;
using Backend.Service;
using MailSender;
using Microsoft.Extensions.Azure;
using QueueStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAzureClients(client =>
{
    client.AddClient<QueueClient, QueueClientOptions>((options, _, _) =>
    {
        options.MessageEncoding = QueueMessageEncoding.Base64;
        var connectionQueue = builder.Configuration["Queue:Connection"];
        var queueName = builder.Configuration["Queue:QueueName"];
        return new QueueClient(connectionQueue, queueName,options);
    });
});

builder.Services.AddScoped<IMailSenderService, SendGridMailService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleManagerService, SaleManagerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
