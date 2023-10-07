using KriegBot.API;
using KriegBot.API.Github;
using KriegBot.Common;
using Octokit.Webhooks;
using Octokit.Webhooks.AspNetCore;

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

app.MapControllers();

app.Run();
