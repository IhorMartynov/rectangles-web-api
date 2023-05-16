using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Geometry;

internal sealed class VerticalLineFunction : ILineFunction
{
    private readonly double _x;

    /// <summary>
    /// Creates a vertical line object that goes through the point.
    /// </summary>
    /// <param name="point"></param>
    public VerticalLineFunction(Point point) =>
        _x = point.X;

    /// <inheritdoc />
    public bool IsPointUpper(Point point) => false;

    /// <inheritdoc />
    public bool IsPointLower(Point point) => false;

    /// <inheritdoc />
    public bool IsPointOnTheLeft(Point point) => point.X < _x;

    /// <inheritdoc />
    public bool IsPointOnTheRight(Point point) => point.X > _x;
}