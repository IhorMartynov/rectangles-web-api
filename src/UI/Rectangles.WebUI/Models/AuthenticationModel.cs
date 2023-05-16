namespace Rectangles.WebUI.Models;

/// <summary>
/// Authentication model.
/// </summary>
/// <param name="UserName">User name</param>
/// <param name="Password">Password</param>
public sealed record AuthenticationModel(string UserName, string Password);