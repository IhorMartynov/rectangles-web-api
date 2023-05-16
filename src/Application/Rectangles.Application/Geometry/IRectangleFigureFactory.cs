using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Geometry;

public interface IRectangleFigureFactory
{
    /// <summary>
    /// Creates an IRectangleFigure object with the given four vertices.
    /// </summary>
    IRectangleFigure Create(Point vertex1, Point vertex2, Point vertex3, Point vertex4);
}