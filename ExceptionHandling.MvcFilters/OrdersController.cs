using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandlingExamples.MvcFilters;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => throw new Exception("Failed");
}