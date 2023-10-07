using Grpc.Core;
using KriegBot.API.GRPC;

namespace KriegBot.API;

public class BotCommunicationService : KriegBot.Slack.GRPC.BotCommunication.BotCommunicationClient
{
    private readonly ILogger<BotCommunicationService> _logger;
    public BotCommunicationService(ILogger<BotCommunicationService> logger)
    {
        _logger = logger;
    }
}