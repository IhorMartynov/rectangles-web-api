using Rectangles.Application.Geometry;
using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Tests.Geometry;

public sealed class VerticalLineFunctionTests
{
    [Test]
    [TestCase(5, -10, 10, true)]
    [TestCase(5, 10, -10, false)]
    [TestCase(5, 10, 0, false)]
    [TestCase(5, 5, 0, false)]
    public void GIVEN_Point_WHEN_IsPointOnTheLeftCalled_THEN_ReturnsExpectedValue(double lineX, double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        var lineFunction = new VerticalLineFunction(new Point(lineX, 0));

        // Act
        var result = lineFunction.IsPointOnTheLeft(point);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    [TestCase(5, -10, 10, false)]
    [TestCase(5, 10, -10, true)]
    [TestCase(5, 10, 0, true)]
    [TestCase(5, 5, 0, false)]
    public void GIVEN_Point_WHEN_IsPointOnTheRightCalled_THEN_ReturnsExpectedValue(double lineX, double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        var lineFunction = new VerticalLineFunction(new Point(lineX, 0));

        // Act
        var result = lineFunction.IsPointOnTheRight(point);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    [TestCase(5, -10, 10, false)]
    [TestCase(5, 10, -10, false)]
    [TestCase(5, 10, 0, false)]
    [TestCase(5, 5, 0, false)]
    public void GIVEN_Point_WHEN_IsPointUpperCalled_THEN_ReturnsExpectedValue(double lineX, double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        var lineFunction = new VerticalLineFunction(new Point(lineX, 0));

        // Act
        var result = lineFunction.IsPointUpper(point);

        // Assert
        result.Should().Be(expectedResult);
    }
    [Test]
    [TestCase(5, -10, 10, false)]
    [TestCase(5, 10, -10, false)]
    [TestCase(5, 10, 0, false)]
    [TestCase(5, 5, 0, false)]
    public void GIVEN_Point_WHEN_IsPointLowerCalled_THEN_ReturnsExpectedValue(double lineX, double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        var lineFunction = new VerticalLineFunction(new Point(lineX, 0));

        // Act
        var result = lineFunction.IsPointLower(point);

        // Assert
        result.Should().Be(expectedResult);
    }
}