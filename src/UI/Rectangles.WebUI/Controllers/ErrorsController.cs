using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Rectangles.WebUI.Controllers;

/// <summary>
/// Errors reporting.
/// </summary>
[ApiController]
public sealed class ErrorsController : ControllerBase
{

    /// <summary>
    /// Reports the unhandled exception.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("/error")]
    public IActionResult Error()
    {
        var error = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Problem(title: error?.Message);
    }
}