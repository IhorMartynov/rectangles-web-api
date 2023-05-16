using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Geometry;

internal sealed class HorizontalLineFunction : ILineFunction
{
    private readonly double _y;

    /// <summary>
    /// Creates a horizontal line object that goes through the point.
    /// </summary>
    /// <param name="point"></param>
    public HorizontalLineFunction(Point point) =>
        _y = point.Y;

    /// <inheritdoc />
    public bool IsPointUpper(Point point) => point.Y > _y;

    /// <inheritdoc />
    public bool IsPointLower(Point point) => point.Y < _y;

    /// <inheritdoc />
    public bool IsPointOnTheLeft(Point point) => false;

    /// <inheritdoc />
    public bool IsPointOnTheRight(Point point) => false;
}