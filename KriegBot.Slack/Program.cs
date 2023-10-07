// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using KriegBot.Slack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
builder.Services.AddSingleton<IModuleService, ModuleService>();
builder.Services.AddHostedService<HostedService>();
    
builder.Services.AddSingleton(Channel.CreateUnbounded<ModuleCommandRequest>());
builder.Services.AddSingleton(Channel.CreateUnbounded<ModuleCommandReply>());

var app = builder.Build();

app.MapGrpcService<BotCommunicationService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();