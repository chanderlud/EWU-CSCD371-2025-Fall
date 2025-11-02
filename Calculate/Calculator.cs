using System.Numerics;

namespace Calculate;

public class Calculator<TOperand> where TOperand : INumber<TOperand>
{
    public static IReadOnlyDictionary<char, Func<TOperand, TOperand, TOperand>> MathematicalOperations { get; }
            = new Dictionary<char, Func<TOperand, TOperand, TOperand>>
            {
                ['+'] = Add,
                ['-'] = Subtract,
                ['*'] = Multiply,
                ['/'] = Divide
            };

    public static TOperand Add(TOperand a, TOperand b) => a + b;

    public static TOperand Subtract(TOperand a, TOperand b) => a - b;

    public static TOperand Multiply(TOperand a, TOperand b) => a * b;

    public static TOperand Divide(TOperand a, TOperand b) => a / b;

    public bool TryCalculate(string calculation, out TOperand result, IFormatProvider? provider = null)
    {
        result = TOperand.Zero;
        if (string.IsNullOrWhiteSpace(calculation))
            return false;

        string[] tokens = calculation.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<string> postfix = [];
        Stack<char> operators = new();
        Stack<TOperand> evaluationStack = new();

        Dictionary<char, int> precedence = new()
        {
            ['+'] = 1,
            ['-'] = 1,
            ['*'] = 2,
            ['/'] = 2
        };

        foreach (string token in tokens)
        {
            if (TOperand.TryParse(token, provider, out _))
            {
                postfix.Add(token);
            }
            else if (token.Length == 1 && MathematicalOperations.ContainsKey(token[0]))
            {
                char op = token[0];
                while (operators.Count > 0 && precedence[operators.Peek()] >= precedence[op])
                    postfix.Add(operators.Pop().ToString());

                operators.Push(op);
            }
            else
            {
                // Invalid token, not an int or operator
                return false;
            }
        }

        while (operators.Count > 0)
            postfix.Add(operators.Pop().ToString());

        foreach (string token in postfix)
        {
            if (TOperand.TryParse(token, provider, out TOperand? number))
            {
                evaluationStack.Push(number);
            }
            else if (token.Length == 1 && MathematicalOperations.TryGetValue(token[0], out var op))
            {
                // if two operands are not available, invalid postfix syntax has occured
                if (evaluationStack.Count < 2)
                    return false;

                TOperand b = evaluationStack.Pop();
                TOperand a = evaluationStack.Pop();

                // divide by 0 is not allowed
                if (token[0] == '/' && b == TOperand.Zero)
                    return false;

                evaluationStack.Push(op(a, b));
            }
            else
            {
                // invalid token in postfix expression
                return false;
            }
        }

        // invalid postfix expression
        if (evaluationStack.Count != 1)
            return false;

        result = evaluationStack.Pop();
        return true;
    }
}
