using ESRun.Interpreter.Errors;
using ESRun.Interpreter.EsEnvironmentRecord.Abstract;
using ESRun.Interpreter.LanguageTypes;

namespace ESRun.Interpreter.EsEnvironmentRecord.DeclarativeEnvironmentRecord;

public class DeclarativeEnvironmentRecord : EnvironmentRecord
{
    public DeclarativeEnvironmentRecord(EnvironmentRecord? outerEnv = null) : base(outerEnv)
    {
    }

    private readonly Dictionary<string, EsBinding> _bindings = new();

    public override bool HasBinding(string bindingName) => _bindings.ContainsKey(bindingName);

    public override void CreateMutableBinding(string bindingName, bool canBeDeleted)
    {
        if (!HasBinding(bindingName))
        {
            _bindings[bindingName] = new EsBinding(isMutable: true, canBeDeleted);
        }
    }

    public override void CreateImmutableBinding(string bindingName, bool isStrict)
    {
        if (!HasBinding(bindingName))
        {
            _bindings[bindingName] = new EsBinding(isMutable: false, canBeDeleted: false, isStrict);
        }
    }

    public override void InitializeBinding(string bindingName, EsValue value)
    {
        if (HasBinding(bindingName) && _bindings[bindingName].Value == null)
        {
            _bindings[bindingName].Value = value;
        }
    }

    public override void SetMutableBinding(string bindingName, EsValue value, bool strict)
    {
        if (!HasBinding(bindingName))
        {
            if (strict)
            {
                throw new ReferenceError($"Binding '{bindingName}' does not exist");
            }

            CreateImmutableBinding(bindingName, strict);
            InitializeBinding(bindingName, value);

            return;
        }

        var binding = _bindings[bindingName];

        if (binding.Value == null)
        {
            throw new ReferenceError($"Binding '{bindingName}' has not been initialized");
        }

        if (binding.IsMutable)
        {
            binding.Value = value;
        }
        else if (binding.IsStrict || strict)
        {
            throw new TypeError($"Cannot modify immutable binding '{bindingName}'");
        }
    }

    public override EsValue GetBindingValue(string bindingName, bool strict)
    {
        if (HasBinding(bindingName))
        {
            var binding = _bindings[bindingName];

            if (binding.Value == null)
            {
                throw new ReferenceError($"Binding '{bindingName}' has not been initialized");
            }

            return binding.Value;
        }

        if (strict)
        {
            throw new ReferenceError($"Binding '{bindingName}' does not exist");
        }

        return EsUndefined.Instance;
    }

    public override bool DeleteBinding(string bindingName)
    {
        if (HasBinding(bindingName))
        {
            var binding = _bindings[bindingName];

            if (!binding.CanBeDeleted)
            {
                return false;
            }

            _bindings.Remove(bindingName);
        }

        return true;
    }

    public override bool HasThisBinding() => false;

    public override bool HasSuperBinding() => false;

    public override EsValue WithBaseObject() => EsUndefined.Instance;
}
