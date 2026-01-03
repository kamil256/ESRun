namespace EsRun.Specification.ExecutableCodeAndExecutionContexts.EnvironmentRecords.DeclarativeEnvironmentRecord;

public class ModuleEnvironmentRecord : DeclarativeEnvironmentRecord
{
    public ModuleEnvironmentRecord(GlobalEnvironmentRecord? outerEnv = null) : base(outerEnv)
    {
    }
}
