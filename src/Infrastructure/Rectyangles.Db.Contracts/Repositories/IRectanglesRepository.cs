using Rectangles.Db.Contracts.Models;

namespace Rectangles.Db.Contracts.Repositories;

public interface IRectanglesRepository
{
    /// <summary>
    /// Asynchronously retrieves all rectangles from the data store.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>The task result contains a collection of rectangles.</returns>
    Task<IEnumerable<Rectangle>> GetAllRectanglesAsync(CancellationToken  cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves a collection of rectangles containing the specified point.
    /// </summary>
    /// <param name="x">The x-coordinate of the point.</param>
    /// <param name="y">The y-coordinate of the point.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>The task result contains a collection of rectangles containing the specified point.</returns>
    Task<IEnumerable<Rectangle>> GetRectanglesContainingPointAsync(double x, double y,
        CancellationToken cancellationToken = default);
}