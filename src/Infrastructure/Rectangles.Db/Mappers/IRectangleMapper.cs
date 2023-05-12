using Rectangles.Db.Contracts.Models;
using Rectangles.Db.Models;

namespace Rectangles.Db.Mappers;

public interface IRectangleMapper
{
    /// <summary>
    /// Maps a RectangleEntity to a Rectangle.
    /// </summary>
    Rectangle Map(RectangleEntity entity);
}