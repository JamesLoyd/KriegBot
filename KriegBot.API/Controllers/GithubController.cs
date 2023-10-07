using Microsoft.AspNetCore.Mvc;

namespace KriegBot.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GithubController : ControllerBase
{
    
    public IActionResult Post(GithubWebhook.GhWebhook webhook)
    {
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(webhook.PayloadObject));
        if (webhook.Event == GithubWebhook.Events.PullRequestEvent.EventString)
        {
            Console.WriteLine("That's a cool pull request");
        }
        return Ok();
    }
}
