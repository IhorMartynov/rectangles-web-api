using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Geometry;

internal sealed class LineFunction : ILineFunction
{
    private readonly double _ax;
    private readonly double _bx;
    private readonly double _ay;
    private readonly double _by;

    public LineFunction(Point p1, Point p2)
    {
        var deltaX = p1.X - p2.X;
        var deltaY = p1.Y - p2.Y;

        _ax = deltaY / deltaX;
        _bx = p1.Y - _ax * p1.X;

        _ay = deltaX / deltaY;
        _by = p1.X - _ay * p1.Y;
    }

    public bool IsPointUpper(Point point) => point.Y > GetY(point.X);

    public bool IsPointLower(Point point) => point.Y < GetY(point.X);

    public bool IsPointOnTheLeft(Point point) => point.X < GetX(point.Y);

    public bool IsPointOnTheRight(Point point) => point.X > GetX(point.Y);

    private double GetX(double y) => _ay * y + _by;

    private double GetY(double x) => _ax * x + _bx;
}