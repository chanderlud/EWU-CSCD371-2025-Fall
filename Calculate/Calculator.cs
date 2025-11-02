namespace Calculate;

public class Calculator
{
    public static IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; }
            = new Dictionary<char, Func<int, int, int>>
            {
                ['+'] = Add,
                ['-'] = Subtract,
                ['*'] = Multiply,
                ['/'] = Divide
            };

    public static int Add(int a, int b) => a + b;

    public static int Subtract(int a, int b) => a - b;

    public static int Multiply(int a, int b) => a * b;

    public static int Divide(int a, int b) => a / b;

    public bool TryCalculate(string calculation, out int result)
    {
        string[] parts = calculation.Split(' ');

        result = 0;
        return true;
    }

}
