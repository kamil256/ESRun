// using System.Runtime.CompilerServices;
// using Esprima.Ast;
// using ESRun.Interpreter.EsProcessors.Abstract;
// using ESRun.Interpreter.EsScope;
// using ESRun.Interpreter.EsTypes.Abstract;
// using ESRun.Interpreter.EsTypes.Function;
// using ESRun.Interpreter.LanguageTypes;

// namespace ESRun.Interpreter.EsProcessors;

// public class ArrowFunctionExpressionProcessor : INodeProcessor<ArrowFunctionExpression, FunctionValue>
// {
//     private readonly Lazy<INodeProcessor<BlockStatement, EsValue>> _blockStatementProcessor;

//     public ArrowFunctionExpressionProcessor(
//         Lazy<INodeProcessor<BlockStatement, EsValue>> blockStatementProcessor)
//     {
//         _blockStatementProcessor = blockStatementProcessor;
//     }

//     public FunctionValue Process(ArrowFunctionExpression node, Scope scope)
//     {
//         if (node.Body is not BlockStatement blockStatement)
//         {
//             throw new NotImplementedException("Only block statement bodies are supported in arrow functions.");
//         }

//         var call = new Func<EsValue, EsValue[], EsValue>((thisContext, _arguments) => _blockStatementProcessor.Value.Process(blockStatement, scope));

//         return new FunctionValue(call, scope);
//     }
// }