using ESRun.Interpreter.EsEnvironmentRecord.Abstract;
using ESRun.Interpreter.LanguageTypes;

namespace ESRun.Interpreter.EsEnvironmentRecord;

public class GlobalEnvironmentRecord : EnvironmentRecord
{
    public GlobalEnvironmentRecord() : base(null)
    {
    }

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
