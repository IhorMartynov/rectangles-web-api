using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rectangles.Db.Contracts.Models;

namespace Rectangles.Db.Models;

internal sealed class RectanglesContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public DbSet<RectangleEntity> Rectangles { get; set; }

    public RectanglesContext(DbContextOptions<RectanglesContext> options)
        : base(options)
    {
        if (!Database.EnsureCreated()) return;

        SeedData();
    }

    private void SeedData()
    {
        var random = new Random();

        for (var i = 0; i < 200; i++)
        {
            var (x1, y1, x2, y2, x3, y3, x4, y4) = GetRandomRectangle(random);

            Rectangles.Add(new RectangleEntity
            {
                X1 = x1, Y1 = y1,
                X2 = x2, Y2 = y2,
                X3 = x3, Y3 = y3,
                X4 = x4, Y4 = y4
            });
        }

        SaveChanges();
    }

    /// <summary>
    /// Generates random rectangle coordinates.
    /// (x3; y3) +-----------------+ (x4; y4)
    ///          |                 |
    ///          |                 |
    /// (x1; y1) +-----------------+ (x2; y2)
    /// </summary>
    /// <param name="random"></param>
    /// <returns></returns>
    private (double, double, double, double, double, double, double, double) GetRandomRectangle(Random random)
    {
        var x1 = random.NextDouble() * 200 - 100;
        var y1 = random.NextDouble() * 200 - 100;

        var a = random.NextDouble() * 19 + 1;
        var b = random.NextDouble() * 19 + 1;

        var sin = random.NextDouble();
        var cos = 1 - sin;

        var x2 = x1 + cos * b;
        var y2 = y1 + sin * b;

        var x3 = x1 - sin * a;
        var y3 = y1 + cos * a;

        var x4 = x3 + (x2 - x1);
        var y4 = y3 + (y2 - y1);

        return (x1, y1, x2, y2, x3, y3, x4, y4);
    }
}