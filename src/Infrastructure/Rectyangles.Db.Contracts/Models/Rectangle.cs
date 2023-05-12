namespace Rectangles.Db.Contracts.Models;

public sealed record Rectangle(long Id, Point Vertex1, Point Vertex2, Point Vertex3, Point Vertex4);

public sealed record Point(double X, double Y);