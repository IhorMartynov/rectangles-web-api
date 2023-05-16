using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Geometry;

internal sealed class RectangleFigureFactory : IRectangleFigureFactory
{
    private readonly ILineFunctionFactory _lineFunctionFactory;

    public RectangleFigureFactory(ILineFunctionFactory lineFunctionFactory)
    {
        _lineFunctionFactory = lineFunctionFactory;
    }

    /// <inheritdoc />
    public IRectangleFigure Create(Point vertex1, Point vertex2, Point vertex3, Point vertex4) =>
        new RectangleFigure(_lineFunctionFactory, vertex1, vertex2, vertex3, vertex4);
}