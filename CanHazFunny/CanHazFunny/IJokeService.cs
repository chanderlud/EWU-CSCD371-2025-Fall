namespace CanHazFunny;

/// <summary>
/// Provides an interface for retrieving jokes from a source.
/// </summary>
public interface IJokeService
{
    /// <summary>
    /// Retrieves a joke.
    /// </summary>
    /// <returns>The joke text.</returns>
    string GetJoke();
}
