//using Esprima;
//using Esprima.Ast;
//using ESRun.Interpreter;
//using ESRun.Interpreter.EsProcessors.Abstract;
//using ESRun.Interpreter.EsTypes.Abstract;
//using ESRun.Interpreter.EsTypes.Function;
//using ESRun.Interpreter.EsTypes.Number;
//using ESRun.Interpreter.EsTypes.Object;
//using ESRun.Interpreter.EsTypes.Undefined;

//namespace ESRun.GUI;

//public class EsInterpreter
//{
//    protected readonly Lazy<INodeProcessor<Script, EsValue>> _scriptProcessor;

//    public EsInterpreter(Lazy<INodeProcessor<Script, EsValue>> scriptProcessor)
//    {
//        _scriptProcessor = scriptProcessor;
//    }

//    public void Run()
//    {
//        var parser = new JavaScriptParser();
//        var inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.js");
//        var input = File.ReadAllText(inputFilePath);
//        var script = parser.ParseScript(input);

//        Scope globalThisScope = new Scope(null)
//        {
//            Variables = { }
//        };

//        var builtInObject = new FunctionValue(false, globalThisScope);
//        builtInObject.Properties["someKey"] = new SimplePropertyDescriptor(new NumberValue("2"));
//        builtInObject.Properties["someKey2"] = new SimplePropertyDescriptor(UndefinedValue.Instance);

//        var builtInConsole = new ObjectValue(new Dictionary<string, SimplePropertyDescriptor>
//        {
//            {
//                "log",
//                new SimplePropertyDescriptor(
//                    new FunctionValue(
//                        false,
//                        globalThisScope, "__log__"))
//            }
//        });

//        var globalThisObject = new ObjectValue(new Dictionary<string, SimplePropertyDescriptor>
//        {
//            { "Object", new SimplePropertyDescriptor(builtInObject) },
//            { "console", new SimplePropertyDescriptor(builtInConsole) },
//            { "someNumber", new SimplePropertyDescriptor(new NumberValue("3.45")) }
//        });

//        globalThisScope.Variables["globalThis"] = new Variable("globalThis", VariableDeclarationKind.Const, globalThisObject);

//        // ManualResetEventSlim pauseEvent = new(true);

//        // var cancellationTokenSource = new CancellationTokenSource();


//        // Task.Run(() =>
//        // {
//        //     DoWork(pauseEvent, cancellationTokenSource.Token);
//        //     Console.WriteLine("Work done.");
//        //     // _scriptProcessor.Value.Process(script, new Scope(globalThisScope));
//        //     // while (true)
//        //     // {
//        //     //     Thread.Sleep(1000);
//        //     // }
//        // });
//        _scriptProcessor.Value.Process(script, new Scope(globalThisScope));
//        // var task = Task.Run(() =>
//        // {

//        //     while (true)
//        //     {
//        //         Thread.Sleep(5000);
//        //         pauseEvent.Set();
//        //     }
//        // });

//        // Thread.Sleep(7000);
//        // cancellationTokenSource.Cancel();


//        // Console.WriteLine("Press Enter to continue...");
//        // Console.ReadLine();
//    }

//    public static void DoWork(ManualResetEventSlim pauseEvent, CancellationToken cancellationToken = default)
//    {
//        foreach (var item in Enumerable.Range(0, 5))
//        {
//            if (cancellationToken.IsCancellationRequested)
//            {
//                Console.WriteLine("Work cancelled.");
//                return;
//            }

//            Console.WriteLine($"Doing work {item + 1}...");
//            pauseEvent.Reset();
//            pauseEvent.Wait(cancellationToken);
//        }
//    }

//    // public static void Log(Node node)
//    // {
//    //     Console.WriteLine(node.ToJsonString("  "));
//    // }
//}