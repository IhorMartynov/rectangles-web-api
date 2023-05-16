namespace Rectangles.Application.Contracts.Services;

public interface IJwtTokenFactory
{
    /// <summary>
    /// Creates JWT token for the user.
    /// </summary>
    /// <param name="userName">User name.</param>
    /// <param name="email">Email</param>
    /// <param name="id">User identifier.</param>
    /// <param name="roles">Assigned roles.</param>
    /// <returns></returns>
    string Create(string userName, string email, string id, params string[] roles);
}