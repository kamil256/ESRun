using ESRun.Interpreter.LanguageTypes;

namespace ESRun.Interpreter.EsEnvironmentRecord;

public class EsBinding
{
    public EsBinding(bool isMutable, bool canBeDeleted, bool isStrict = false)
    {
        IsMutable = isMutable;
        CanBeDeleted = canBeDeleted;
        IsStrict = isStrict;
        // IsInitialized = false;
    }

    public EsValue? Value { get; set; }

    public bool IsMutable { get; }

    // public bool IsInitialized { get; set; }
    public bool CanBeDeleted { get; }

    public bool IsStrict { get; }
}
