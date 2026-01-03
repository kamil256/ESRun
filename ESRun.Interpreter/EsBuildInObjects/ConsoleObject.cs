// using ESRun.Interpreter.EsScope;
// using ESRun.Interpreter.EsTypes.Abstract;
// using ESRun.Interpreter.EsTypes.Function;
// using ESRun.Interpreter.EsTypes.Object;
// using ESRun.Interpreter.EsTypes.String;
// using ESRun.Interpreter.EsTypes.Undefined;
// using ESRun.Interpreter.LanguageTypes;
// using ESRun.Interpreter.Logging;

// namespace ESRun.Interpreter.EsBuildInObjects;

// public class ConsoleObject : ObjectValue
// {
//     private static ConsoleObject? _instance;

//     private EsValue Log(EsValue thisContext, EsValue[] arguments)
//     {
//         LoggerHelper.LogInfo(arguments[0] ?? UndefinedValue.Instance);

//         return UndefinedValue.Instance;
//     }

//     private ConsoleObject()
//     {
//         DefineOwnProperty(new StringValue("log"), new DataPropertyDescriptor(new FunctionValue(Log, new Scope())));
//     }

//     public static ConsoleObject Instance => _instance ??= new ConsoleObject();
// }
