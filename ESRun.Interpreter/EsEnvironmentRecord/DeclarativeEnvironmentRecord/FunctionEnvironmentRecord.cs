using ESRun.Interpreter.EsEnvironmentRecord.Abstract;

namespace ESRun.Interpreter.EsEnvironmentRecord.DeclarativeEnvironmentRecord;

public class FunctionEnvironmentRecord : DeclarativeEnvironmentRecord
{
    public FunctionEnvironmentRecord(EnvironmentRecord? outerEnv = null) : base(outerEnv)
    {
    }
}
