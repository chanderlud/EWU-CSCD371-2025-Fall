namespace CanHazFunny;

/// <summary>
/// Defines a contract for outputting jokes to a destination,
/// such as the console or a text writer.
/// </summary>
public interface IJokeOutput
{
    /// <summary>
    /// Writes the specified joke to the output destination.
    /// </summary>
    /// <param name="joke">The joke text to display.</param>
    void PrintJoke(string joke);
}
