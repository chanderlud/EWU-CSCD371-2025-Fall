using System;

namespace CanHazFunny;

public class Jester(IJokeOutput jokeOutput, IJokeService jokeService)
{
    public IJokeOutput JokeOutput { get; } = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
    public IJokeService JokeService { get; } = jokeService ?? throw new ArgumentNullException(nameof(jokeService));

    public void TellJoke()
    {
        string? filteredJoke = null;

        while (filteredJoke is null)
        {
            string joke = JokeService.GetJoke();

            if (!joke.Contains("chuck norris", StringComparison.OrdinalIgnoreCase))
            {
                filteredJoke = joke;
            }
        }

        JokeOutput.PrintJoke(filteredJoke);
    }
}
