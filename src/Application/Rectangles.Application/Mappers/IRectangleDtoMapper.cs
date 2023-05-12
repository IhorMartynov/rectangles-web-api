using Rectangles.Application.Contracts.Models;
using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Mappers;

public interface IRectangleDtoMapper
{
    /// <summary>
    /// Maps a Rectangle object to a RectangleDto object.
    /// </summary>
    RectangleDto Map(Rectangle rectangle);
}