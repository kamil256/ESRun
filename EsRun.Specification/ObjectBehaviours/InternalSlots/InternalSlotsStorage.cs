namespace EsRun.Specification.ObjectBehaviours.InternalSlots;

public class InternalSlotsStorage
{
    private readonly List<IInternalSlot> _internalSlots;

    public InternalSlotsStorage(List<IInternalSlot> internalSlots)
    {
        var slotTypes = internalSlots.Select(slot => slot.GetType()).ToList();

        if (slotTypes.Count != slotTypes.Distinct().Count())
        {
            throw new ArgumentException("Duplicate internal slots are not allowed in InternalSlotsStorage.");
        }

        _internalSlots = internalSlots;
    }

    public bool Has<T>() where T : IInternalSlot
    {
        return _internalSlots.OfType<T>().Any();
    }

    public void Add(IInternalSlot internalSlot)
    {
        if (Has<IInternalSlot>())
        {
            throw new InvalidOperationException($"Internal slot of type '{internalSlot.GetType().Name}' already exists.");
        }

        _internalSlots.Add(internalSlot);
    }

    public T Get<T>() where T : IInternalSlot => _internalSlots.OfType<T>().FirstOrDefault()
        ?? throw new KeyNotFoundException($"Internal slot of type '{typeof(T).Name}' not found.");
}