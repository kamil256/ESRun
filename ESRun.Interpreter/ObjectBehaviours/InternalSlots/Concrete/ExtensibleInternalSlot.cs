using ESRun.Interpreter.ObjectBehaviours.InternalSlots.Abstract;

namespace ESRun.Interpreter.ObjectBehaviours.InternalSlots.Concrete;

public class ExtensibleInternalSlot : IInternalSlot
{
    public string Name => "[[Extensible]]";
    public bool? Value { get; set; }
}