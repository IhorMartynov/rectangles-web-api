using MediatR;
using Rectangles.Application.Contracts.Models;

namespace Rectangles.Application.Contracts.Requests;

public sealed class GetAllRectanglesRequest : IRequest<IEnumerable<RectangleDto>>
{
}