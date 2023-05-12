namespace Rectangles.Application.Contracts.Models;

/// <summary>
/// Rectangle vertices.
/// </summary>
/// <param name="Vertex1">Vertex 1</param>
/// <param name="Vertex2">Vertex 2</param>
/// <param name="Vertex3">Vertex 3</param>
/// <param name="Vertex4">Vertex 4</param>
public sealed record RectangleDto(PointDto Vertex1, PointDto Vertex2, PointDto Vertex3, PointDto Vertex4);
