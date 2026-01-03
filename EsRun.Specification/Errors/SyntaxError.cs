namespace EsRun.Specification.Errors;

public class SyntaxError : Exception
{
    public SyntaxError(string message) : base(message)
    {
    }

    public override string ToString()
    {
        return $"SyntaxError: {Message}";
    }
}