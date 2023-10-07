using System.Threading.Channels;
using Grpc.Core;
using KriegBot.API.GRPC;
using Microsoft.Extensions.Logging;
using Channel = System.Threading.Channels.Channel;

namespace KriegBot.Slack;

public class BotCommunicationService : BotCommunication.BotCommunicationBase
{
    private readonly ILogger<BotCommunicationService> _logger;
    private readonly Channel<ModuleCommandRequest> _channel;
    public BotCommunicationService(ILogger<BotCommunicationService> logger, Channel<ModuleCommandRequest> channel )
    {
        _logger = logger;
        _channel = channel;
    }

    public override async Task<MessageReply> SendMessage(Message request, ServerCallContext context)
    {
        Console.WriteLine("RECIEVED" + request.Name + "with payload" + request.Payload);
        await _channel.Writer.WriteAsync(new ModuleCommandRequest
        {
            Name = request.Name,
            Payload = request.Payload
        });
        
        return new MessageReply
        {
            Message = "test"
        };
    }
}