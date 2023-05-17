namespace Rectangles.Application.Contracts.Models;

public sealed record RectanglesContainingPointDto(PointDto Point, IEnumerable<RectangleDto> Rectangles);