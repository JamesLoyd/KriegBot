using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KriegBot.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
[AllowAnonymous]
public class GithubController : ControllerBase
{
    
    [HttpPost]
    public IActionResult Post(GithubWebhook.GhWebhook webhook)
    {
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(webhook));
        if (webhook.Event == GithubWebhook.Events.PullRequestEvent.EventString)
        {
            Console.WriteLine("That's a cool pull request");
        }
        return Ok();
    }
}
