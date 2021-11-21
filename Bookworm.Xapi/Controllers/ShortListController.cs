using Microsoft.AspNetCore.Mvc;

[Route("private/shortlist")]
public class ShortListController : ControllerBase
{
  public IActionResult Get() => Ok("private short list");
}