using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;
public class Jester
{
    private IJokeOutput JokeOutput;
    private IJokeService JokeService;

    public Jester(IJokeOutput jokeOutput, IJokeService jokeService)
    {
        JokeOutput = jokeOutput;
        JokeService = jokeService;
    }

    public void TellJoke()
    {
        JokeOutput.PrintJoke(JokeService.GetJoke());
    }
}
