using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Rectangles.Application.Contracts.Services;
using Rectangles.Db.Contracts.Models;
using Rectangles.WebUI.Models;

namespace Rectangles.WebUI.Controllers;

/// <summary>
/// User authentication.
/// </summary>
[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IJwtTokenFactory _jwtTokenFactory;

    /// <summary>
    /// Constructor for AccountController class.
    /// </summary>
    /// <param name="userManager">UserManager object for managing users.</param>
    /// <param name="jwtTokenFactory">JWT token factory.</param>
    public AccountController(UserManager<ApplicationUser> userManager, IJwtTokenFactory jwtTokenFactory)
    {
        _userManager = userManager;
        _jwtTokenFactory = jwtTokenFactory;
    }

    /// <summary>
    /// Authenticates a user.
    /// </summary>
    /// <param name="model">User name and password.</param>
    /// <returns>JWT token to use as Bearer.</returns>
    [HttpPost]
    [Route("login")]
    [Produces(typeof(string))]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Login([FromBody]AuthenticationModel model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user is null 
            || !await _userManager.CheckPasswordAsync(user, model.Password))
            return Forbid();

        var token = _jwtTokenFactory.Create(user.UserName, user.Email, user.Id.ToString());

        return Ok(token);
    }
}