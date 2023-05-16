using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Geometry;

internal interface ILineFunction
{
    /// <summary>
    /// Checks if the given Point is located above the line.
    /// </summary>
    bool IsPointUpper(Point point);

    /// <summary>
    /// Checks if the given Point is located below the line.
    /// </summary>
    bool IsPointLower(Point point);

    /// <summary>
    /// Checks if the given Point is located on the left of the line.
    /// </summary>
    bool IsPointOnTheLeft(Point point);

    /// <summary>
    /// Checks if the given Point is located on the right of the line.
    /// </summary>
    bool IsPointOnTheRight(Point point);
}