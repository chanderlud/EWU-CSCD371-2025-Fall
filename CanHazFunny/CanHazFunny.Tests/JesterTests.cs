using Moq;
using System;
using System.IO;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    [Fact]
    public void Constructor_WithValidDependencies_SetsProperties()
    {
        // Arrange
        Mock<IJokeOutput> outputMock = new();
        Mock<IJokeService> serviceMock = new();

        // Act
        Jester jester = new(outputMock.Object, serviceMock.Object);

        // Assert
        Assert.Same(outputMock.Object, jester.JokeOutput);
        Assert.Same(serviceMock.Object, jester.JokeService);
    }

    [Fact]
    public void Constructor_WithNullOutput_ThrowsArgumentNullException()
    {
        // Arrange
        Mock<IJokeService> serviceMock = new();

        // Act
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new Jester(null!, serviceMock.Object));

        // Assert
        Assert.Equal("jokeOutput", ex.ParamName);
    }

    [Fact]
    public void Constructor_WithNullService_ThrowsArgumentNullException()
    {
        // Arrange
        Mock<IJokeOutput> outputMock = new();

        // Act
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new Jester(outputMock.Object, null!));

        // Assert
        Assert.Equal("jokeService", ex.ParamName);
    }

    [Fact]
    public void TellJoke_CallsGetJoke_And_PrintJoke_WithReturnedValue()
    {
        // Arrange
        string expectedJoke = "Why did the developer go broke? Because he used up all his cache.";

        Mock<IJokeOutput> outputMock = new();
        Mock<IJokeService> serviceMock = new();
        serviceMock.Setup(s => s.GetJoke()).Returns(expectedJoke);

        Jester jester = new(outputMock.Object, serviceMock.Object);

        // Act
        jester.TellJoke();

        // Assert
        serviceMock.Verify(s => s.GetJoke(), Times.Once);
        outputMock.Verify(o => o.PrintJoke(expectedJoke), Times.Once);
    }

    [Fact]
    public void TellJoke_WhenServiceReturnsEmptyString_StillCallsPrintJoke()
    {
        // Arrange
        Mock<IJokeOutput> outputMock = new();
        Mock<IJokeService> serviceMock = new();
        serviceMock.Setup(s => s.GetJoke()).Returns(string.Empty);

        Jester jester = new(outputMock.Object, serviceMock.Object);

        // Act
        jester.TellJoke();

        // Assert
        outputMock.Verify(o => o.PrintJoke(string.Empty), Times.Once);
    }

    [Fact]
    public void TellJoke_WhenServiceThrows_PropagatesException()
    {
        // Arrange
        Mock<IJokeOutput> outputMock = new();
        Mock<IJokeService> serviceMock = new();
        serviceMock.Setup(s => s.GetJoke()).Throws(new InvalidOperationException("bad joke source"));

        Jester jester = new(outputMock.Object, serviceMock.Object);

        // Act + Assert
        InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => jester.TellJoke());
        Assert.Equal("bad joke source", ex.Message);
    }

    [Fact]
    public void TellJoke_WhenOutputThrows_PropagatesException()
    {
        // Arrange
        Mock<IJokeOutput> outputMock = new();
        Mock<IJokeService> serviceMock = new();
        serviceMock.Setup(s => s.GetJoke()).Returns("Some joke");
        outputMock.Setup(o => o.PrintJoke(It.IsAny<string>())).Throws(new IOException("printer jam"));

        Jester jester = new(outputMock.Object, serviceMock.Object);

        // Act + Assert
        IOException ex = Assert.Throws<IOException>(() => jester.TellJoke());
        Assert.Equal("printer jam", ex.Message);
    }
}
