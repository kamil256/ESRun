using ESRun.Interpreter.EsTypes.Abstract;

namespace ESRun.Interpreter.SpecificationTypes.CompletionRecord;

public class CompletionRecord<TValue>
{
    private CompletionRecord(CompletionRecordType type, TValue value, string? target)
    {
        Type = type;
        Value = value;
        Target = target;
    }

    public CompletionRecordType Type { get; }
    public TValue Value { get; }
    public string? Target { get; }

    public static CompletionRecord<TValue> NormalCompletion(TValue value)
    {
        return new CompletionRecord<TValue>(CompletionRecordType.Normal, value, null);
    }

    public static CompletionRecord<EsValue> ThrowCompletion(EsValue value)
    {
        return new CompletionRecord<EsValue>(CompletionRecordType.Throw, value, null);
    }

    public static CompletionRecord<EsValue> ReturnCompletion(EsValue value)
    {
        return new CompletionRecord<EsValue>(CompletionRecordType.Return, value, null);
    }

    public static CompletionRecord<object> UpdateEmpty(CompletionRecord<object> completionRecord, object value)
    {
        if ((completionRecord.Type == CompletionRecordType.Return || completionRecord.Type == CompletionRecordType.Throw) && completionRecord.Value == null)
        {
            throw new InvalidOperationException("Cannot update empty completions of types return and throw.");
        }

        if (completionRecord.Value is not null)
        {
            return completionRecord;
        }

        return new CompletionRecord<object>(completionRecord.Type, value, completionRecord.Target);
    }
}
