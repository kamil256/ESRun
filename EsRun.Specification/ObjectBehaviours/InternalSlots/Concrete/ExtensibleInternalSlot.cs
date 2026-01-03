
public class ExtensibleInternalSlot : IInternalSlot
{
    public string Name => "[[Extensible]]";
    public bool? Value { get; set; }
}