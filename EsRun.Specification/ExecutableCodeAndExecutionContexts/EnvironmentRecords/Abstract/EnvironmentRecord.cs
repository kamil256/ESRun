using EsRun.Specification.LanguageTypes.Abstract;

namespace EsRun.Specification.ExecutableCodeAndExecutionContexts.EnvironmentRecords.Abstract;

public abstract class EnvironmentRecord
{
    protected virtual EnvironmentRecord? OuterEnv { get; }

    public EnvironmentRecord(EnvironmentRecord? outerEnv = null)
    {
        OuterEnv = outerEnv;
    }

    public abstract bool HasBinding(string bindingName);

    public abstract void CreateMutableBinding(string bindingName, bool canBeDeleted);

    public abstract void CreateImmutableBinding(string bindingName, bool strict);

    public abstract void InitializeBinding(string bindingName, EsValue value);

    public abstract void SetMutableBinding(string bindingName, EsValue value, bool strict);

    public abstract EsValue GetBindingValue(string bindingName, bool strict);

    public abstract bool DeleteBinding(string bindingName);

    public abstract bool HasThisBinding();

    public abstract bool HasSuperBinding();

    public abstract EsValue WithBaseObject();
}
