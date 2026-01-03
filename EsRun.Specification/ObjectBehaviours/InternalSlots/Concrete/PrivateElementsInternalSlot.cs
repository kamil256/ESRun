using EsRun.Specification.LanguageTypes.Concrete;

namespace EsRun.Specification.ObjectBehaviours.InternalSlots.Concrete;

public class PrivateElementsInternalSlot : IInternalSlot
{
    public string Name => "[[PrivateElements]]";
    public EsList? Value { get; set; }
}