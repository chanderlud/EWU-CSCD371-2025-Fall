using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class JokeOutputTests
{
    [Fact]
    public void PrintJoke_WritesToProvidedTextWriter()
    {
        // Arrange
        StringWriter writer = new();
        JokeOutput output = new(writer);

        // Act
        output.Write("Knock knock");

        // Assert
        Assert.Equal("Knock knock" + Environment.NewLine, writer.ToString());
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void PrintJoke_WithNullOrEmptyInput_ThrowsArgumentException(string? badInput)
    {
        // Arrange
        JokeOutput output = new();

        // Act
        ArgumentException ex = Assert.Throws<ArgumentException>(() => output.Write(badInput!));

        // Assert
        Assert.Equal("joke", ex.ParamName);
    }

    [Fact]
    public void Constructor_WithoutParameters_SetsWriterToConsoleOut()
    {
        // Arrange
        JokeOutput output = new();

        // Act
        TextWriter writer = output.Writer;

        // Assert
        Assert.Same(Console.Out, writer);
    }
}
