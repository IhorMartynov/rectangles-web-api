using MediatR;
using Rectangles.Application.Contracts.Models;

namespace Rectangles.Application.Contracts.Requests;

/// <summary>
/// Search for rectangles containing points.
/// </summary>
public sealed class SearchForRectanglesContainingPointsRequest : IRequest<IEnumerable<RectangleDto>>
{
    public PointDto[] Points { get; set; }

    public SearchForRectanglesContainingPointsRequest(PointDto[] points)
    {
        Points = points;
    }
}