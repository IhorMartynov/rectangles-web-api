using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Geometry;

/// <summary>
/// Interface for creating line functions.
/// </summary>
internal interface ILineFunctionFactory
{
    /// <summary>
    /// Creates a line function object from two points. 
    /// </summary>
    /// <param name="point1">The first point.</param>
    /// <param name="point2">The second point.</param>
    /// <returns>A line function object.</returns>
    ILineFunction Create(Point point1, Point point2);
}