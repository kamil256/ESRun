namespace ESRun.Interpreter.Errors;

public class ReferenceError : Exception
{
    public ReferenceError(string identifier) : base($"{identifier} is not defined")
    {
    }

    public override string ToString()
    {
        return $"ReferenceError: {Message}";
    }
}