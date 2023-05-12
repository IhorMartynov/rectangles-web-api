using MediatR;
using Rectangles.Application.Contracts.Models;
using Rectangles.Application.Contracts.Requests;
using Rectangles.Application.Mappers;
using Rectangles.Db.Contracts.Repositories;

namespace Rectangles.Application.Handlers;

public sealed class GetAllRectanglesRequestHandler : IRequestHandler<GetAllRectanglesRequest, IEnumerable<RectangleDto>>
{
    private readonly IRectanglesRepository _rectanglesRepository;
    private readonly IRectangleDtoMapper _mapper;

    public GetAllRectanglesRequestHandler(IRectanglesRepository rectanglesRepository, IRectangleDtoMapper mapper)
    {
        _rectanglesRepository = rectanglesRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RectangleDto>> Handle(GetAllRectanglesRequest request, CancellationToken cancellationToken)
    {
        var rectangleEntities = await _rectanglesRepository.GetAllRectanglesAsync(cancellationToken);

        return rectangleEntities.Select(_mapper.Map);
    }
}