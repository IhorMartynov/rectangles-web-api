using Rectangles.Db.Contracts.Models;
using Rectangles.Db.Models;

namespace Rectangles.Db.Mappers
{
    internal sealed class RectangleMapper : IRectangleMapper
    {
        /// <inheritdoc />
        public Rectangle Map(RectangleEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            return new Rectangle(
                entity.Id,
                new Point(entity.X1, entity.Y1),
                new Point(entity.X2, entity.Y2),
                new Point(entity.X3, entity.Y3),
                new Point(entity.X4, entity.Y4)
            );
        }
    }
}
