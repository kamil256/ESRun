
namespace ESRun.Interpreter.EsTypes.Abstract;

public abstract class EsValue
{
    public abstract string ToString(int nestingLevel);
    public abstract EsValue Clone();
}