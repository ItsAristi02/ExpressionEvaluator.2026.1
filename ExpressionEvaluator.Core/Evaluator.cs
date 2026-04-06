namespace ExpressionEvaluator.Core;

public class Evaluator
{
    public static double Evaluate(string infix)
    {
        if (string.IsNullOrEmpty(infix))
            throw new Exception("Please enter an expression.");
        var parts = PreValidations(infix);
        var postfix = InfixToPostfix(parts);
        return EvaluatePostfix(postfix);
    }
    private static List<string> PreValidations(string infix)
    {
        var parts = new List<string>();
        var number = string.Empty;

        for (int i = 0; i < infix.Length; i++)
        {
            var item = infix[i];

            if (item == '-' && (i == 0 || infix[i - 1] == '('))
            {
                number += item;
            }
            else if (char.IsDigit(item) || item == '.')
            {
                number += item;
            }
            else
            {
                if (number != string.Empty)
                {
                    parts.Add(number);
                    number = string.Empty;
                }
                parts.Add(item.ToString());
            }
        }

        if (number != string.Empty)
            parts.Add(number);

        for (int i = 0; i < parts.Count - 1; i++)
        {
            var current = parts[i];
            var next = parts[i + 1];

            if (!IsOperator(current) && next == "(")
                throw new Exception($"Missing operator before '('.");

            if (current == ")" && !IsOperator(next))
                throw new Exception($"Missing operator after ')'.");

            if (current == ")" && next == "(")
                throw new Exception($"Missing operator between ')('.");
        }

        return parts;
    }
    private static List<string> InfixToPostfix(List<string> tokens)
    {
        var postFix = new List<string>();
        var stack = new Stack<string>();
        foreach (var item in tokens)
        {
            if (IsOperator(item))
            {
                if (stack.Count == 0)
                {
                    stack.Push(item);
                }
                else
                {
                    if (item == ")")
                    {
                        do
                        {
                            postFix.Add(stack.Pop());
                        } while (stack.Peek() != "(");
                        stack.Pop();
                    }
                    else
                    {
                        if (PriorityInfix(item) > PriorityStack(stack.Peek()))
                        {
                            stack.Push(item);
                        }
                        else
                        {
                            postFix.Add(stack.Pop());
                            stack.Push(item);
                        }
                    }
                }
            }
            else
            {
                postFix.Add(item);
            }
        }
        while (stack.Count > 0)
        {
            postFix.Add(stack.Pop());
        }
        return postFix;
    }
    private static int PriorityStack(string item) => item switch
    {
        "^" => 3,
        "*" => 2,
        "/" => 2,
        "+" => 1,
        "-" => 1,
        "(" => 0,
        _ => throw new Exception("Sintax error."),
    };
    private static int PriorityInfix(string item) => item switch
    {
        "^" => 4,
        "*" => 2,
        "/" => 2,
        "+" => 1,
        "-" => 1,
        "(" => 5,
        _ => throw new Exception("Sintax error."),
    };
    private static double EvaluatePostfix(List<string> postfix)
    {
        var stack = new Stack<double>();
        foreach (var item in postfix)
        {
            if (IsOperator(item))
            {
                var b = stack.Pop();
                var a = stack.Pop();
                stack.Push(item switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => b == 0 ? throw new Exception("Division by zero is not allowed.") : a / b,
                    "^" => Math.Pow(a, b),
                    _ => throw new Exception("Sintax error."),
                });
            }
            else
            {
                stack.Push(double.Parse(item, System.Globalization.CultureInfo.InvariantCulture));
            }
        }
        return stack.Pop();
    }
    private static bool IsOperator(string item) => "+-*/^()".Contains(item);
}