using KriegBot.API;
using KriegBot.API.Github;
using KriegBot.Common;
using Octokit.Webhooks;
using Octokit.Webhooks.AspNetCore;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<WebhookEventProcessor, WebhookProcessor>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGitHubWebhooks(path: "/api/github",  EnvironmentHelper.GetEnviromentVariableValue(Constants.EnvironmentVariableNames.GithubWebhookSecret));
});


app.MapGrpcService<BotCommunicationService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


app.MapControllers();

app.Run();
