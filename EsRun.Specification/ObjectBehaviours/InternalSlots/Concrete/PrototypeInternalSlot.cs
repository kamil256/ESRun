using EsRun.Specification.LanguageTypes.Concrete;

namespace EsRun.Specification.ObjectBehaviours.InternalSlots.Concrete;

public class PrototypeInternalSlot : IInternalSlot
{
    public string Name => "[[Prototype]]";
    public EsObject? Value { get; set; }
}