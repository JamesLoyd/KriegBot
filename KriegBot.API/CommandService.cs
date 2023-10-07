using Grpc.Net.Client;
using KriegBot.API.GRPC;
using KriegBot.Slack.GRPC;

namespace KriegBot.API;

public interface ICommandService
{
    Task SendCommandAsync(string name, string payload);
}

public class CommandService : ICommandService
{
    public CommandService()
    {
    }
    public async Task SendCommandAsync(string name, string payload)
    {
        using var channel = GrpcChannel.ForAddress("http://192.168.86.36:5164");
        var client = new KriegBot.Slack.GRPC.BotCommunication.BotCommunicationClient(channel);

        await client.SendMessageAsync(new Message
        {
            Name = name,
            Payload = payload
        });
    }
}