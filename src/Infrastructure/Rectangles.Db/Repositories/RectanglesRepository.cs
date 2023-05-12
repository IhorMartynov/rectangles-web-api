using Microsoft.EntityFrameworkCore;
using Rectangles.Db.Contracts.Models;
using Rectangles.Db.Contracts.Repositories;
using Rectangles.Db.Mappers;
using Rectangles.Db.Models;

namespace Rectangles.Db.Repositories
{
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
            var entities = await _context.Rectangles.ToArrayAsync(cancellationToken);

            return entities.Select(_mapper.Map);
        }

        /// <inheritdoc />
        public Task<IEnumerable<Rectangle>> GetRectanglesContainingPointAsync(double x, double y, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
