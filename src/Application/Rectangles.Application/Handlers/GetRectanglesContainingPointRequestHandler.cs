using MediatR;
using Rectangles.Application.Contracts.Models;
using Rectangles.Application.Contracts.Requests;
using Rectangles.Application.Geometry;
using Rectangles.Application.Mappers;
using Rectangles.Db.Contracts.Models;
using Rectangles.Db.Contracts.Repositories;

namespace Rectangles.Application.Handlers;

public sealed class GetRectanglesContainingPointRequestHandler
    : IRequestHandler<GetRectanglesContainingPointRequest, IEnumerable<RectangleDto>>
{
    private readonly IRectanglesRepository _rectanglesRepository;
    private readonly IRectangleDtoMapper _mapper;
    private readonly IRectangleFigureFactory _rectangleFigureFactory;


    public GetRectanglesContainingPointRequestHandler(
        IRectanglesRepository rectanglesRepository,
        IRectangleDtoMapper mapper,
        IRectangleFigureFactory rectangleFigureFactory)
    {
        _rectanglesRepository = rectanglesRepository;
        _mapper = mapper;
        _rectangleFigureFactory = rectangleFigureFactory;
    }

    public async Task<IEnumerable<RectangleDto>> Handle(GetRectanglesContainingPointRequest request,
        CancellationToken cancellationToken)
    {
        var point = new Point(request.X, request.Y);

        var rectangleEntities = await _rectanglesRepository.GetRectanglesCloseToPointAsync(request.X, request.Y, cancellationToken);

        var rectangles = new List<RectangleDto>();
        foreach (var rectangleEntity in rectangleEntities)
        {
            var rectangleFigure = _rectangleFigureFactory.Create(rectangleEntity.Vertex1, rectangleEntity.Vertex2,
                rectangleEntity.Vertex3, rectangleEntity.Vertex4);

            if (!rectangleFigure.ContainsPoint(point)) continue;

            rectangles.Add(_mapper.Map(rectangleEntity));
        }

        return rectangles;
    }
}