using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Geometry;

internal sealed class LineFunctionFactory : ILineFunctionFactory
{
    private const double CloseToZero = 0.000001;

    /// <inheritdoc />
    public ILineFunction Create(Point point1, Point point2)
    {
        var deltaX = Math.Abs(point1.X - point2.X);
        var deltaY = Math.Abs(point1.Y - point2.Y);

        if (deltaX < CloseToZero && deltaY < CloseToZero)
            throw new ArgumentException("Points are too close to each other. Cannot create a line function.", nameof(point1));

        if (deltaY < CloseToZero) return new HorizontalLineFunction(point1);

        if (deltaX < CloseToZero) return new VerticalLineFunction(point1);

        return new LineFunction(point1, point2);
    }
}