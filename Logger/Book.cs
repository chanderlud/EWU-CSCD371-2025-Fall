namespace Logger;

public record class Book : EntityBase
{
    private string Title { get; init; }
    private string Author { get; init; }

    /// <summary>
    /// Implemented implicitly since Name is part of a Book's public identity
    /// </summary>
    public override string Name => $"{Title} by {Author}";

    public Book(string title, string author)
    {
        Title = string.IsNullOrWhiteSpace(title)
                ? throw new ArgumentException($"'{nameof(title)}' cannot be null or whitespace.", nameof(title))
                : title;
        Author = string.IsNullOrWhiteSpace(author)
                ? throw new ArgumentException($"'{nameof(author)}' cannot be null or whitespace.", nameof(author))
                : author;
    }
}
