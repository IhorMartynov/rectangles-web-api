using MediatR;
using Rectangles.Application.Contracts.Models;
using Rectangles.Application.Contracts.Requests;
using Rectangles.Application.Geometry;
using Rectangles.Application.Mappers;
using Rectangles.Db.Contracts.Models;
using Rectangles.Db.Contracts.Repositories;

namespace Rectangles.Application.Handlers;

public sealed class SearchForRectanglesContainingPointsRequestHandler
    : IRequestHandler<SearchForRectanglesContainingPointsRequest, IEnumerable<RectanglesContainingPointDto>>
{
    private readonly IRectanglesRepository _rectanglesRepository;
    private readonly IRectangleDtoMapper _mapper;
    private readonly IRectangleFigureFactory _rectangleFigureFactory;

    public SearchForRectanglesContainingPointsRequestHandler(
        IRectanglesRepository rectanglesRepository,
        IRectangleDtoMapper mapper,
        IRectangleFigureFactory rectangleFigureFactory)
    {
        _rectanglesRepository = rectanglesRepository;
        _mapper = mapper;
        _rectangleFigureFactory = rectangleFigureFactory;
    }

    public async Task<IEnumerable<RectanglesContainingPointDto>> Handle(SearchForRectanglesContainingPointsRequest request,
        CancellationToken cancellationToken)
    {
        var points = request.Points
            .Select(p => new Point(p.X, p.Y))
            .ToArray();

        var rectangleEntities = await _rectanglesRepository.GetRectanglesCloseToPointsAsync(points, cancellationToken);

        var pointsWithRectanglesDictionary = points.ToDictionary(p => p, p => new List<RectangleDto>());
        foreach (var rectangleEntity in rectangleEntities)
        {
            var rectangleFigure = _rectangleFigureFactory.Create(rectangleEntity.Vertex1, rectangleEntity.Vertex2,
                rectangleEntity.Vertex3, rectangleEntity.Vertex4);

            var pointsInside = points.Where(rectangleFigure.ContainsPoint).ToArray();

            if (pointsInside.Length <= 0) continue;

            foreach (var point in pointsInside)
            {
                pointsWithRectanglesDictionary[point].Add(_mapper.Map(rectangleEntity));
            }
        }

        return pointsWithRectanglesDictionary.Select(p =>
                new RectanglesContainingPointDto(new PointDto(p.Key.X, p.Key.Y), p.Value))
            .ToArray();
    }
}