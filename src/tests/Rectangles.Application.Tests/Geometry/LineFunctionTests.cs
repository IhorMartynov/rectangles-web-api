using Rectangles.Application.Geometry;
using Rectangles.Db.Contracts.Models;

namespace Rectangles.Application.Tests.Geometry;

public sealed class LineFunctionTests
{
    private readonly ILineFunction _lineFunction;

    public LineFunctionTests()
    {
        _lineFunction = new LineFunction(new Point(-1, -1), new Point(1, 1));
    }

    [Test]
    [TestCase(0, -1, false)]
    [TestCase(0, 1, true)]
    [TestCase(-1, 0, true)]
    [TestCase(1, 0, false)]
    [TestCase(0, 0, false)]
    public void GIVEN_Point_WHEN_IsPointOnTheLeftCalled_THEN_ReturnsExpectedValue(double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        // Act
        var result = _lineFunction.IsPointOnTheLeft(point);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    [TestCase(0, -1, true)]
    [TestCase(0, 1, false)]
    [TestCase(-1, 0, false)]
    [TestCase(1, 0, true)]
    [TestCase(0, 0, false)]
    public void GIVEN_Point_WHEN_IsPointOnTheRightCalled_THEN_ReturnsExpectedValue(double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        // Act
        var result = _lineFunction.IsPointOnTheRight(point);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Test]
    [TestCase(0, -1, false)]
    [TestCase(0, 1, true)]
    [TestCase(-1, 0, true)]
    [TestCase(1, 0, false)]
    [TestCase(0, 0, false)]
    public void GIVEN_Point_WHEN_IsPointUpperCalled_THEN_ReturnsExpectedValue(double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        // Act
        var result = _lineFunction.IsPointUpper(point);

        // Assert
        result.Should().Be(expectedResult);
    }
    [Test]
    [TestCase(0, -1, true)]
    [TestCase(0, 1, false)]
    [TestCase(-1, 0, false)]
    [TestCase(1, 0, true)]
    [TestCase(0, 0, false)]
    public void GIVEN_Point_WHEN_IsPointLowerCalled_THEN_ReturnsExpectedValue(double pointX,
        double pointY, bool expectedResult)
    {
        // Arrange
        var point = new Point(pointX, pointY);

        // Act
        var result = _lineFunction.IsPointLower(point);

        // Assert
        result.Should().Be(expectedResult);
    }
}