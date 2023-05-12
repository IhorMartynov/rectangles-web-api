using MediatR;
using Rectangles.Application.Contracts.Models;
using Rectangles.Application.Contracts.Requests;
using Rectangles.Application.Mappers;
using Rectangles.Db.Contracts.Repositories;

namespace Rectangles.Application.Handlers;

public sealed class GetRectanglesContainingPointRequestHandler
    : IRequestHandler<GetRectanglesContainingPointRequest, IEnumerable<RectangleDto>>
{
    private readonly IRectanglesRepository _rectanglesRepository;
    private readonly IRectangleDtoMapper _mapper;


    public GetRectanglesContainingPointRequestHandler(IRectanglesRepository rectanglesRepository, IRectangleDtoMapper mapper)
    {
        _rectanglesRepository = rectanglesRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RectangleDto>> Handle(GetRectanglesContainingPointRequest request,
        CancellationToken cancellationToken)
    {
        var rectangleEntities = await _rectanglesRepository.GetRectanglesContainingPointAsync(request.X, request.Y, cancellationToken);

        return rectangleEntities.Select(_mapper.Map);
    }
}