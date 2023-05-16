using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Geometry;

/// <summary>
/// Rectangle figure.
/// </summary>
public interface IRectangleFigure
{
    /// <summary>
    /// Checks if a point is contained within the current figure.
    /// </summary>
    /// <param name="point">The point object.</param>
    bool ContainsPoint(Point point);
}