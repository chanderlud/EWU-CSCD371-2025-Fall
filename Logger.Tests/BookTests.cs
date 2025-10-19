using Xunit;

namespace Logger.Tests;

public class BookTests
{
    [Fact]
    public void Constructor_ValidArguments_SetsProperties()
    {
        Book book = new("1984", "George Orwell");

        Assert.Equal("1984 by George Orwell", book.Name);
        Assert.NotEqual(Guid.Empty, book.Id);
    }

    [Theory]
    [InlineData(null, "Author")]
    [InlineData("", "Author")]
    [InlineData("   ", "Author")]
    public void Constructor_InvalidTitle_ThrowsArgumentException(string? title, string author)
    {
        Assert.Throws<ArgumentException>(() => new Book(title!, author));
    }

    [Theory]
    [InlineData("Title", null)]
    [InlineData("Title", "")]
    [InlineData("Title", "   ")]
    public void Constructor_InvalidAuthor_ThrowsArgumentException(string title, string? author)
    {
        Assert.Throws<ArgumentException>(() => new Book(title, author!));
    }
}
