using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Rectangles.Application.Geometry;
using Rectangles.Application.Mappers;

[assembly:InternalsVisibleTo("Rectangles.Application.Tests")]

namespace Rectangles.Application;

public static class RectanglesApplicationServicesExtensions
{
    public static IServiceCollection AddRectangleApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IRectangleDtoMapper, RectangleDtoMapper>()
            .AddSingleton<ILineFunctionFactory, LineFunctionFactory>()
            .AddSingleton<IRectangleFigureFactory, RectangleFigureFactory>();

        return services;
    }
}