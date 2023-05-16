using Microsoft.EntityFrameworkCore;
using Rectangles.Db.Contracts.Models;
using Rectangles.Db.Contracts.Repositories;
using Rectangles.Db.Mappers;
using Rectangles.Db.Models;

namespace Rectangles.Db.Repositories;

internal sealed class RectanglesRepository : IRectanglesRepository
{
    private readonly RectanglesContext _context;
    private readonly IRectangleMapper _mapper;

    public RectanglesRepository(RectanglesContext context, IRectangleMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Rectangle>> GetAllRectanglesAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _context.Rectangles
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);

        return entities.Select(_mapper.Map);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Rectangle>> GetRectanglesCloseToPointAsync(double x, double y, CancellationToken cancellationToken = default)
    {
        var closeEntities = await _context.Rectangles
            .AsNoTracking()
            .Where(r => (x >= r.X1 || x >= r.X2 || x >= r.X3 || x >= r.X4)
                        && (x <= r.X1 || x <= r.X2 || x <= r.X3 || x <= r.X4)
                        && (y >= r.Y1 || y >= r.Y2 || y >= r.Y3 || y >= r.Y4)
                        && (y <= r.Y1 || y <= r.Y2 || y <= r.Y3 || y <= r.Y4))
            .ToArrayAsync(cancellationToken);

        return closeEntities.Select(_mapper.Map);
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Rectangle>> GetRectanglesCloseToPointsAsync(Point[] points, CancellationToken cancellationToken = default)
    {
        if (points is null || !points.Any()) return Enumerable.Empty<Rectangle>();

        var closeEntitiesQuery = _context.Rectangles
            .AsNoTracking();

        foreach (var (x, y) in points)
        {
            closeEntitiesQuery = closeEntitiesQuery.Where(r => (x >= r.X1 || x >= r.X2 || x >= r.X3 || x >= r.X4)
                                                               && (x <= r.X1 || x <= r.X2 || x <= r.X3 || x <= r.X4)
                                                               && (y >= r.Y1 || y >= r.Y2 || y >= r.Y3 || y >= r.Y4)
                                                               && (y <= r.Y1 || y <= r.Y2 || y <= r.Y3 || y <= r.Y4));
        }

        var closeEntities = await closeEntitiesQuery.ToArrayAsync(cancellationToken);

        return closeEntities.Select(_mapper.Map);
    }
}