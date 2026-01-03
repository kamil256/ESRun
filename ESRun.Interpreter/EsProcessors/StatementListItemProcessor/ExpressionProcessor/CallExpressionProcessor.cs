// using Esprima.Ast;
// using ESRun.Interpreter.EsProcessors.Abstract;
// using ESRun.Interpreter.EsScope;
// using ESRun.Interpreter.EsTypes.Abstract;
// using ESRun.Interpreter.EsTypes.Function;
// using ESRun.Interpreter.EsTypes.Null;
// using ESRun.Interpreter.EsTypes.Undefined;
// using ESRun.Interpreter.LanguageTypes;
// using ESRun.Interpreter.SpecificationTypes.CompletionRecord;

// namespace ESRun.Interpreter.EsProcessors;

// public class CallExpressionProcessor : INodeProcessor<CallExpression, EsValue>
// {
//     private readonly Lazy<INodeProcessor<Expression, EsValue>> _expressionProcessor;
//     private readonly Lazy<INodeProcessor<BlockStatement, EsValue>> _blockStatementProcessor;

//     public CallExpressionProcessor(Lazy<INodeProcessor<Expression, EsValue>> expressionProcessor,
//         Lazy<INodeProcessor<BlockStatement, EsValue>> blockStatementProcessor)
//     {
//         _expressionProcessor = expressionProcessor;
//         _blockStatementProcessor = blockStatementProcessor;
//     }

//     public EsValue Process(CallExpression node, Scope scope)
//     {
//         var callee = _expressionProcessor.Value.Process(node.Callee, scope);

//         if (callee is not FunctionValue calleeFunction)
//         {
//             throw new Exception($"Not a function.");
//         }

//         var arguments = node.Arguments.Select(arg => _expressionProcessor.Value.Process(arg, scope)).ToArray();

//         return calleeFunction.Call(NullValue.Instance, arguments).Value;
//     }
// }