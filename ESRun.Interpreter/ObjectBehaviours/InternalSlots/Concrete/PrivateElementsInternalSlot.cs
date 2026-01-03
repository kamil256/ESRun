using ESRun.Interpreter.LanguageTypes;
using ESRun.Interpreter.ObjectBehaviours.InternalSlots.Abstract;

namespace ESRun.Interpreter.ObjectBehaviours.InternalSlots.Concrete;

public class PrivateElementsInternalSlot : IInternalSlot
{
    public string Name => "[[PrivateElements]]";
    public EsList? Value { get; set; }
}