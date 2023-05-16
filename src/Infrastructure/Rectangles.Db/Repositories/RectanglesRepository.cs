using System.Linq.Expressions;
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

        var expressions = points.Select(p =>
        {
            var x = p.X;
            var y = p.Y;

            Expression<Func<RectangleEntity, bool>> expression = r =>
                (x >= r.X1 || x >= r.X2 || x >= r.X3 || x >= r.X4)
                && (x <= r.X1 || x <= r.X2 || x <= r.X3 || x <= r.X4)
                && (y >= r.Y1 || y >= r.Y2 || y >= r.Y3 || y >= r.Y4)
                && (y <= r.Y1 || y <= r.Y2 || y <= r.Y3 || y <= r.Y4);
            return expression;
        }).ToArray();

        var parameter = Expression.Parameter(typeof(RectangleEntity), "r");
        Expression whereExpression = Expression.Invoke(expressions[0], parameter);
        for (var i = 1; i < expressions.Length; ++i)
        {
            whereExpression = Expression.OrElse(whereExpression,
                Expression.Invoke(expressions[i], parameter));
        }

        var whereLambda = Expression.Lambda<Func<RectangleEntity, bool>>(whereExpression, parameter);

        var closeEntities = await _context.Rectangles
            .AsNoTracking()
            .Where(whereLambda)
            .ToArrayAsync(cancellationToken);

        return closeEntities.Select(_mapper.Map);
    }
}