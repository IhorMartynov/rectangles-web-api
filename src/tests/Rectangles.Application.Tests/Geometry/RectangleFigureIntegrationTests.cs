using Rectangles.Application.Geometry;
using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Tests.Geometry;

public sealed class RectangleFigureIntegrationTests
{
    [Test]
    [TestCase(0, 0, true)]
    [TestCase(10, 0, true)]
    [TestCase(10, 10, true)]
    [TestCase(0, 10, true)]
    [TestCase(0, 5, true)]
    [TestCase(5, 5, true)]
    [TestCase(-1, 5, false)]
    [TestCase(11, 5, false)]
    [TestCase(5, -1, false)]
    [TestCase(5, 11, false)]
    [TestCase(-1, -1, false)]
    public void GIVEN_RectangleParallelToAxis_WHEN_ContainsPointCalled_THEN_ReturnsExpectedResult(
        double x, double y, bool expectedResult)
    {
        // Arrange
        var vertex1 = new Point(0, 0);
        var vertex2 = new Point(10, 0);
        var vertex3 = new Point(10, 10);
        var vertex4 = new Point(0, 10);

        var point = new Point(x, y);

        var lineFunctionFactory = new LineFunctionFactory();
        var rectangleFigure = new RectangleFigure(lineFunctionFactory, vertex1, vertex2, vertex3, vertex4);

        // Act
        var result = rectangleFigure.ContainsPoint(point);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    [TestCase(-10, 0, true)]
    [TestCase(0, 10, true)]
    [TestCase(10, 0, true)]
    [TestCase(0, -10, true)]
    [TestCase(5, 5, true)]
    [TestCase(0, 0, true)]
    [TestCase(-6, 6, false)]
    [TestCase(6, 6, false)]
    [TestCase(-6, 6, false)]
    [TestCase(-6, -6, false)]
    [TestCase(-11, 0, false)]
    public void GIVEN_RectangleNotParallelToAxis_WHEN_ContainsPointCalled_THEN_ReturnsExpectedResult(
        double x, double y, bool expectedResult)
    {
        // Arrange
        var vertex1 = new Point(-10, 0);
        var vertex2 = new Point(0, 10);
        var vertex3 = new Point(10, 0);
        var vertex4 = new Point(0, -10);

        var point = new Point(x, y);

        var lineFunctionFactory = new LineFunctionFactory();
        var rectangleFigure = new RectangleFigure(lineFunctionFactory, vertex1, vertex2, vertex3, vertex4);

        // Act
        var result = rectangleFigure.ContainsPoint(point);

        // Assert
        result.Should().Be(expectedResult);
    }
}