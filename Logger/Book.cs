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
        Title = title;
        Author = author;
    }
}
