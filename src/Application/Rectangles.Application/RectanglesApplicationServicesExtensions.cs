using Microsoft.Extensions.DependencyInjection;
using Rectangles.Application.Mappers;

namespace Rectangles.Application;

public static class RectanglesApplicationServicesExtensions
{
    public static IServiceCollection AddRectangleApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IRectangleDtoMapper, RectangleDtoMapper>();

        return services;
    }
}