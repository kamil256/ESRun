using EsRun.Specification.ExecutableCodeAndExecutionContexts.EnvironmentRecords.Abstract;
using EsRun.Specification.LanguageTypes.Abstract;

namespace EsRun.Specification.ExecutableCodeAndExecutionContexts.EnvironmentRecords;

public class ObjectEnvironmentRecord : EnvironmentRecord
{
    public ObjectEnvironmentRecord(EnvironmentRecord? outerEnv = null) : base(outerEnv)
    {
        throw new NotImplementedException();
    }

    public EsValue BindingObject { get; set; }

    public bool IsWithEnvironment { get; set; }

    public override bool HasBinding(string bindingName)
    {
        throw new NotImplementedException();
    }

    public override void CreateMutableBinding(string bindingName, bool canBeDeleted)
    {
        throw new NotImplementedException();
    }

    public override void CreateImmutableBinding(string bindingName, bool strict)
    {
        throw new NotImplementedException();
    }

    public override void InitializeBinding(string bindingName, EsValue value)
    {
        throw new NotImplementedException();
    }

    public override void SetMutableBinding(string bindingName, EsValue value, bool strict)
    {
        throw new NotImplementedException();
    }

    public override EsValue GetBindingValue(string bindingName, bool strict)
    {
        throw new NotImplementedException();
    }

    public override bool DeleteBinding(string bindingName)
    {
        throw new NotImplementedException();
    }

    public override bool HasThisBinding()
    {
        throw new NotImplementedException();
    }

    public override bool HasSuperBinding()
    {
        throw new NotImplementedException();
    }

    public override EsValue WithBaseObject()
    {
        throw new NotImplementedException();
    }
}
