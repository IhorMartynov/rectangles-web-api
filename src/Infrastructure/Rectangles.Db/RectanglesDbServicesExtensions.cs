using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rectangles.Db.Contracts.Repositories;
using Rectangles.Db.Mappers;
using Rectangles.Db.Models;
using Rectangles.Db.Repositories;

namespace Rectangles.Db;

public static class RectanglesDbServicesExtensions
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<RectanglesContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddSingleton<IRectangleMapper, RectangleMapper>();

        services.AddTransient<IRectanglesRepository, RectanglesRepository>();

        return services;
    }
}