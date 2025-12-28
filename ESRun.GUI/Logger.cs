using ESRun.Interpreter.Logging;

namespace ESRun.GUI;

public class Logger : ILogger
{
    private readonly Form1 _form1;

    public Logger(Form1 form1)
    {
        _form1 = form1;
    }

    public void LogInfo(string message)
    {
        _form1.LogInfo(message);
    }
}
