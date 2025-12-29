namespace ESRun.Interpreter.Errors;

public class TypeError : Exception
{
    public TypeError(string message) : base(message)
    {
    }

    public override string ToString()
    {
        return $"TypeError: {Message}";
    }
}