using ESRun.Interpreter.LanguageTypes;
using ESRun.Interpreter.ObjectBehaviours.InternalSlots.Abstract;

namespace ESRun.Interpreter.ObjectBehaviours.InternalSlots.Concrete;

public class PrototypeInternalSlot : IInternalSlot
{
    public string Name => "[[Prototype]]";
    public EsObject? Value { get; set; }
}