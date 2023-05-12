using MediatR;
using Rectangles.Application.Contracts.Models;

namespace Rectangles.Application.Contracts.Requests;

public sealed class GetRectanglesContainingPointRequest : IRequest<IEnumerable<RectangleDto>>
{
    public double X { get; set; }
    public double Y { get; set; }

    public GetRectanglesContainingPointRequest(double x, double y)
    {
        X = x;
        Y = y;
    }
}