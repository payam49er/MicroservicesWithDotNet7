using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers;

[Route("api/c/[controller]/")]
[ApiController]
public class PlatformsController:ControllerBase
{
    public PlatformsController()
    {
    }

    [HttpPost]
    public ActionResult PostSomething()
    {
        return Ok("Inbound test from Command service");
    } 

    [HttpGet]
    public ActionResult GetSomething()
    {
        return Ok("Inbound test from Get Command Service");
    }
}