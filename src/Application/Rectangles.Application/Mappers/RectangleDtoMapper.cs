using Rectangles.Application.Contracts.Models;
using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Mappers;

internal sealed class RectangleDtoMapper : IRectangleDtoMapper
{
    /// <inheritdoc />
    public RectangleDto Map(Rectangle rectangle)
    {
        if (rectangle == null) throw new ArgumentNullException(nameof(rectangle));

        return new RectangleDto(
            new PointDto(rectangle.Vertex1.X, rectangle.Vertex1.Y),
            new PointDto(rectangle.Vertex2.X, rectangle.Vertex2.Y),
            new PointDto(rectangle.Vertex3.X, rectangle.Vertex3.Y),
            new PointDto(rectangle.Vertex4.X, rectangle.Vertex4.Y));
    }
}