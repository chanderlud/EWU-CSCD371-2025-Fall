using System;
using System.IO;

namespace CanHazFunny;


public class JokeOutput(TextWriter? writer = default) : IOutput
{
    public TextWriter Writer { get; } = writer ?? Console.Out;

    public void Write(string joke)
    {
        if (string.IsNullOrWhiteSpace(joke))
        {
            throw new ArgumentException("Joke cannot be null or empty.", nameof(joke));
        }

        Writer.WriteLine(joke);
    }
}
