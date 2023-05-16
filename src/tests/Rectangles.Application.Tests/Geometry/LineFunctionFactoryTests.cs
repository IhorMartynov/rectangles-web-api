using Rectangles.Application.Geometry;
using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Tests.Geometry;

public sealed class LineFunctionFactoryTests
{
    [Test]
    [TestCase(1, 0, -1, 0, typeof(HorizontalLineFunction))]
    [TestCase(0, 1, 0, -1, typeof(VerticalLineFunction))]
    [TestCase(1, 1, -1, -1, typeof(LineFunction))]
    public void GIVEN_TwoPoints_WHEN_CreateCalled_THEN_CreatesCorrectLineFunctionType(
        double x1, double y1, double x2, double y2, Type expectedType)
    {
        // Arrange
        var point1 = new Point(x1, y1);
        var point2 = new Point(x2, y2);

        var factory = new LineFunctionFactory();

        // Act
        var result = factory.Create(point1, point2);

        // Assert
        result.Should().BeOfType(expectedType);
    }

    [Test]
    public void GIVEN_TwoSamePoints_WHEN_CreateCalled_THEN_ThrowsException()
    {
        // Arrange
        var point1 = new Point(2, 3);
        var point2 = new Point(2, 3);

        var factory = new LineFunctionFactory();

        // Act
        var exception = Assert.Throws<ArgumentException>(() => factory.Create(point1, point2));

        // Assert
        exception.Should().NotBeNull();
        exception!.Message.Should().StartWith("Points are too close to each other. Cannot create a line function.");
        exception.ParamName.Should().Be("point1");
    }
}