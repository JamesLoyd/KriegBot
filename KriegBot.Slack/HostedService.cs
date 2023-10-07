using System.Threading.Channels;
using Microsoft.Extensions.Hosting;

namespace KriegBot.Slack;

public class HostedService : IHostedService
{
    public HostedService(Channel<ModuleCommandRequest> channel, IModuleService moduleService)
    {
        
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Hello");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Stopping");
        return Task.CompletedTask;
    }
}