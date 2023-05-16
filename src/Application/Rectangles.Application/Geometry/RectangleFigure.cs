using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Geometry;

/// <inheritdoc />
internal sealed class RectangleFigure : IRectangleFigure
{
    private Point _topLeftVertex;
    private Point _topRightVertex;
    private Point _bottomLeftVertex;
    private Point _bottomRightVertex;

    private ILineFunction _bottomEdge;
    private ILineFunction _topEdge;
    private ILineFunction _leftEdge;
    private ILineFunction _rightEdge;

    private readonly ILineFunctionFactory _lineFunctionFactory;

    public RectangleFigure(ILineFunctionFactory lineFunctionFactory,
        Point vertex1, Point vertex2, Point vertex3, Point vertex4)
    {
        _lineFunctionFactory = lineFunctionFactory;

        PopulateVertices(vertex1, vertex2, vertex3, vertex4);
        PopulateEdges();
    }

    /// <inheritdoc />
    public bool ContainsPoint(Point point)
    {
        if (_leftEdge.IsPointOnTheLeft(point)) return false;

        if (_rightEdge.IsPointOnTheRight(point)) return false;

        if (_topEdge.IsPointUpper(point)) return false;

        if (_bottomEdge.IsPointLower(point)) return false;

        return true;
    }

    private void PopulateVertices(Point vertex1, Point vertex2, Point vertex3, Point vertex4)
    {
        var vertices = new[] {vertex1, vertex2, vertex3, vertex4};
        var verticallySortedVertices = vertices.OrderBy(v => v.Y).ToArray();

        if (verticallySortedVertices[0].X > verticallySortedVertices[1].X)
        {
            _bottomLeftVertex = verticallySortedVertices[1];
            _bottomRightVertex = verticallySortedVertices[0];
        }
        else
        {
            _bottomLeftVertex = verticallySortedVertices[0];
            _bottomRightVertex = verticallySortedVertices[1];
        }

        if (verticallySortedVertices[2].X > verticallySortedVertices[3].X)
        {
            _topLeftVertex = verticallySortedVertices[3];
            _topRightVertex = verticallySortedVertices[2];
        }
        else
        {
            _topLeftVertex = verticallySortedVertices[2];
            _topRightVertex = verticallySortedVertices[3];
        }
    }

    private void PopulateEdges()
    {
        _bottomEdge = _lineFunctionFactory.Create(_bottomLeftVertex, _bottomRightVertex);
        _topEdge = _lineFunctionFactory.Create(_topLeftVertex, _topRightVertex);
        _leftEdge = _lineFunctionFactory.Create(_topLeftVertex, _bottomLeftVertex);
        _rightEdge = _lineFunctionFactory.Create(_topRightVertex, _bottomRightVertex);
    }
}