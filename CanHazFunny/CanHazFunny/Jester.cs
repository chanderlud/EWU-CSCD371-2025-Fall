using System;

namespace CanHazFunny;

public class Jester(IJokeOutput jokeOutput, IJokeService jokeService)
{
    public IJokeOutput JokeOutput { get; } = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
    public IJokeService JokeService { get; } = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    public string BannedSubstring { get; set; } = "chuck norris";

    public void TellJoke()
    {
        string filteredJoke;
        do
        {
            filteredJoke = JokeService.GetJoke();
        } while (filteredJoke.Contains(BannedSubstring, StringComparison.OrdinalIgnoreCase));

        JokeOutput.PrintJoke(filteredJoke);
    }
}
