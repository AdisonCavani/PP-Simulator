using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(15, 1, 10, 10)]
    [InlineData(1, 1, 10, 1)]
    [InlineData(10, 1, 10, 10)]
    public void Limiter_ShouldReturnCorrectClampedValue(int value, int min, int max, int expected)
    {
        // Act
        var result = Validator.Limiter(value, min, max);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("short", 0, 25, '#', "Short")]
    [InlineData("a", 0, 25, '#', "A##")]
    [InlineData("longword", 0, 25, '#', "Longword")]
    [InlineData("     ", 0, 25, '#', "Unknown")]
    [InlineData("  trim test   ", 0, 25, '#', "Trim test")]
    [InlineData("Tiny", 0, 25, '#', "Tiny")]
    [InlineData("small", 0, 10, '#', "Small")]
    public void Shortener_ShouldReturnCorrectShortenedValue(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", 0, 25, '#', "Hello")]
    [InlineData("HELLO", 0, 25, '#', "HELLO")]
    public void Shortener_ShouldUppercaseFirstLetter(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        var result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }
}