namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; } = Console.WriteLine;
    public Func<string?> ReadLine { get; init; } = Console.ReadLine;

    public static void Main() => new Program().Run();

    public void Run()
    {
        Calculator<float> calculator = new();
        bool run = true;

        while (run)
        {
            WriteLine("Enter an equation (enter exit to exit): ");
            string? equation = ReadLine();
            if (equation is not null)
            {
                if (equation is "exit")
                {
                    WriteLine("Goodbye");
                    run = false;
                } else if (calculator.TryCalculate(equation, out float result))
                {
                    WriteLine($"Result: {result}");
                }
                else
                {
                    WriteLine("Invalid equation");
                }
            }
        }
    }
}