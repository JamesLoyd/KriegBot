using Grpc.Core;
using KriegBot.API.GRPC;

namespace KriegBot.API;

public class BotCommunicationService : KriegBot.API.GRPC.BotCommunication.BotCommunicationBase
{
    private readonly ILogger<BotCommunicationService> _logger;
    public BotCommunicationService(ILogger<BotCommunicationService> logger)
    {
        _logger = logger;
    }
}