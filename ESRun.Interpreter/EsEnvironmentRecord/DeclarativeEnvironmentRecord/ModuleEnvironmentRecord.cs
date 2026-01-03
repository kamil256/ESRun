namespace ESRun.Interpreter.EsEnvironmentRecord.DeclarativeEnvironmentRecord;

public class ModuleEnvironmentRecord : DeclarativeEnvironmentRecord
{
    public ModuleEnvironmentRecord(GlobalEnvironmentRecord? outerEnv = null) : base(outerEnv)
    {
    }
}
