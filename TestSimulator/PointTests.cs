using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(1, 1, Direction.Right, 2, 1)]
    [InlineData(5, 5, Direction.Down, 5, 4)]
    public void Next_ShouldReturnCorrectNextPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(startX, startY);

        // Act
        var nextPoint = point.Next(direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(1, 1, Direction.Right, 2, 0)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int startX, int startY, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(startX, startY);

        // Act
        var nextPoint = point.NextDiagonal(direction);

        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}