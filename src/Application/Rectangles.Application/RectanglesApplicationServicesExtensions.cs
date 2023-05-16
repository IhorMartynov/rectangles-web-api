using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Rectangles.Application.Contracts.Services;
using Rectangles.Application.Geometry;
using Rectangles.Application.Mappers;
using Rectangles.Application.Services;

[assembly: InternalsVisibleTo("Rectangles.Application.Tests")]

namespace Rectangles.Application;

public static class RectanglesApplicationServicesExtensions
{
    /// <summary>
    /// Add application layer services.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddRectangleApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IRectangleDtoMapper, RectangleDtoMapper>()
            .AddSingleton<ILineFunctionFactory, LineFunctionFactory>()
            .AddSingleton<IRectangleFigureFactory, RectangleFigureFactory>();

        return services;
    }

    /// <summary>
    /// Add Jwt token generation services.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="expirationMinutes">Token expiration minutes.</param>
    /// <param name="audience">Token audience.</param>
    /// <param name="issuer">Token issuer.</param>
    /// <param name="issuerSigningKey">Token issuer signing key.</param>
    /// <param name="subject">Token subject.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddJwtTokenServices(this IServiceCollection services, int expirationMinutes,
    string audience,
    string issuer,
    string issuerSigningKey,
    string subject)
    {
        services.AddSingleton<IJwtTokenFactory>(sp =>
            new JwtTokenFactory(expirationMinutes, audience, issuer, issuerSigningKey, subject));

        return services;
    }
}