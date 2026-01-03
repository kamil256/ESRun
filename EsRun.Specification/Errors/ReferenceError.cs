namespace EsRun.Specification.Errors;

public class ReferenceError : Exception
{
    public ReferenceError(string message) : base(message)
    {
    }

    public override string ToString()
    {
        return $"ReferenceError: {Message}";
    }
}