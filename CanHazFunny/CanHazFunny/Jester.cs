using System;

namespace CanHazFunny;

public sealed class Jester(IJokeOutput jokeOutput, IJokeService jokeService)
{
    public IJokeOutput JokeOutput { get; } = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));
    public IJokeService JokeService { get; } = jokeService ?? throw new ArgumentNullException(nameof(jokeService));

    public void TellJoke()
    {
        JokeOutput.PrintJoke(JokeService.GetJoke());
    }
}
