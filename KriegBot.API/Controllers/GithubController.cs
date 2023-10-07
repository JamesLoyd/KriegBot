using Microsoft.AspNetCore.Mvc;

namespace KriegBot.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GithubController : ControllerBase
{
    public IActionResult Post()
    {
        return Ok();
    }
}
