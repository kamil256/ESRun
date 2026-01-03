// using ESRun.Interpreter.EsScope;
// using ESRun.Interpreter.EsTypes.Abstract;
// using ESRun.Interpreter.EsTypes.Object;
// using ESRun.Interpreter.LanguageTypes;
// using ESRun.Interpreter.SpecificationTypes.CompletionRecord;

// namespace ESRun.Interpreter.EsTypes.Function;

// public class FunctionValue : ObjectValue
// {
//     protected Func<EsValue?, EsValue[], EsValue> _call;

//     public FunctionValue(Func<EsValue?, EsValue[], EsValue> call, Scope scope)
//     {
//         _call = call;
//         Scope = scope;
//     }

//     public EsValue Call(EsValue? thisContext, EsValue[] arguments)
//     {
//         var result = _call(thisContext, arguments);

//         return result;
//     }

//     public Scope Scope { get; set; }

//     public override string ToString(int nestingLevel)
//     {
//         var temporaryConstructorName = "Object";
//         var result = $"function {temporaryConstructorName}()";
//         var indentation = new string(' ', 2 * (nestingLevel + 1));

//         foreach (var propertyKey in OwnPropertyKeys().Value)
//         {
//             var descriptor = GetOwnProperty(propertyKey).Value;

//             if (descriptor is DataPropertyDescriptor dataPropertyDescriptor)
//             {
//                 if (dataPropertyDescriptor.Value is ObjectValue nestedObject)
//                 {
//                     result += $"{indentation}{propertyKey}: ";
//                     result += nestedObject.ToString(nestingLevel + 1);
//                 }
//                 else
//                 {
//                     result += $"\r\n{indentation}{propertyKey}: {dataPropertyDescriptor.Value}";
//                 }
//             }
//         }

//         return result;
//     }
// }