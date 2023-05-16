using Rectangles.Application.Geometry;
using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Tests.Geometry;

public sealed class HorizontalLineFunctionTests
{
    [Test]
    [TestCase(5, -1, 10, false)]
    [TestCase(5, 1, -10, false)]
    [TestCase(5, 0, 10, false)]
    public void GIVEN_Point_WHEN_IsPointOnTheLeftCalled_THEN_ReturnsExpectedValue(double lineY, double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        var lineFunction = new HorizontalLineFunction(new Point(0, lineY));

        // Act
        var result = lineFunction.IsPointOnTheLeft(point);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    [TestCase(5, -1, 10, false)]
    [TestCase(5, 1, -10, false)]
    [TestCase(5, 0, 10, false)]
    public void GIVEN_Point_WHEN_IsPointOnTheRightCalled_THEN_ReturnsExpectedValue(double lineY, double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        var lineFunction = new HorizontalLineFunction(new Point(0, lineY));

        // Act
        var result = lineFunction.IsPointOnTheRight(point);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    [TestCase(5, -1, 10, true)]
    [TestCase(5, 1, 10, true)]
    [TestCase(5, 0, -10, false)]
    [TestCase(5, 0, 5, false)]
    public void GIVEN_Point_WHEN_IsPointUpperCalled_THEN_ReturnsExpectedValue(double lineY, double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        var lineFunction = new HorizontalLineFunction(new Point(0, lineY));

        // Act
        var result = lineFunction.IsPointUpper(point);

        // Assert
        result.Should().Be(expectedResult);
    }
    [Test]
    [TestCase(5, -1, 10, false)]
    [TestCase(5, 1, 10, false)]
    [TestCase(5, 0, -10, true)]
    [TestCase(5, 0, 5, false)]
    public void GIVEN_Point_WHEN_IsPointLowerCalled_THEN_ReturnsExpectedValue(double lineY, double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        var lineFunction = new HorizontalLineFunction(new Point(0, lineY));

        // Act
        var result = lineFunction.IsPointLower(point);

        // Assert
        result.Should().Be(expectedResult);
    }
}