using EsRun.Specification.ExecutableCodeAndExecutionContexts.EnvironmentRecords.Abstract;

namespace EsRun.Specification.ExecutableCodeAndExecutionContexts.EnvironmentRecords.DeclarativeEnvironmentRecord;

public class FunctionEnvironmentRecord : DeclarativeEnvironmentRecord
{
    public FunctionEnvironmentRecord(EnvironmentRecord? outerEnv = null) : base(outerEnv)
    {
    }
}
