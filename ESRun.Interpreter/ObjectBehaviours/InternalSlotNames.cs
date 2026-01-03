using ESRun.Interpreter.LanguageTypes;

namespace ESRun.Interpreter.ObjectBehaviours;

public interface IInternalSlot<TValue>
{
    string Name { get; }
    TValue Value { get; set; }
}

static class InternalSlotNames
{
    public const string Prototype = "[[Prototype]]";
    public const string Extensible = "[[Extensible]]";
    public const string PrivateElements = "[[PrivateElements]]";
    public const string Value = "[[Value]]";
    public const string Writable = "[[Writable]]";
    public const string Get = "[[Get]]";
    public const string Set = "[[Set]]";
}
