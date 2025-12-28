using ESRun.Interpreter;
using ESRun.Interpreter.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ESRun.GUI;

static class Program
{
    public static IServiceProvider Services { get; private set; }

    static Program()
    {
        var services = new ServiceCollection();
        services.RegisterServices();
        services.AddSingleton<ILogger, Logger>();
        services.AddSingleton<Form1>();
        Services = services.BuildServiceProvider();
    }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var logger = Services.GetRequiredService<ILogger>();
        LoggerHelper.RegisterLogger(logger);

        var form1 = Services.GetRequiredService<Form1>();
        Application.Run(form1);
    }
}