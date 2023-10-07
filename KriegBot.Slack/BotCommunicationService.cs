using Grpc.Core;
using KriegBot.API.GRPC;
using Microsoft.Extensions.Logging;

namespace KriegBot.Slack;

public class BotCommunicationService : BotCommunication.BotCommunicationBase
{
    private readonly ILogger<BotCommunicationService> _logger;
    public BotCommunicationService(ILogger<BotCommunicationService> logger)
    {
        _logger = logger;
    }

    public override Task<MessageReply> SendMessage(Message request, ServerCallContext context)
    {
        Console.WriteLine("RECIEVED" + request.Name + "with payload" + request.Payload);
        return Task.FromResult(new MessageReply
        {
            Message = "test"
        });
    }
}