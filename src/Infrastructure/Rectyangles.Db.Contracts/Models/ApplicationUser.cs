using Microsoft.AspNetCore.Identity;

namespace Rectangles.Db.Contracts.Models;

public sealed class ApplicationUser : IdentityUser<Guid>
{
}