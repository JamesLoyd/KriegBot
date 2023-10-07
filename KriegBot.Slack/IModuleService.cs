using System.Threading.Channels;

namespace KriegBot.Slack;

public interface IModuleService
{
    
}
//NOTE: For now we are just going to call one module, we will need to make it
// extensible later
public class ModuleService : IModuleService
{
    public ModuleService(Channel<ModuleCommandRequest> channel)
    {
        
    }
}