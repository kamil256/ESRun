// using Esprima.Ast;
// using ESRun.Interpreter.EsProcessors.Abstract;
// using ESRun.Interpreter.EsScope;
// using ESRun.Interpreter.LanguageTypes;

// namespace ESRun.Interpreter.EsProcessors;

// public class FunctionExpressionProcessor : INodeProcessor<FunctionExpression, EsValue>
// {
//     private readonly Lazy<INodeProcessor<BlockStatement, EsValue>> _blockStatementProcessor;

//     public FunctionExpressionProcessor(
//         Lazy<INodeProcessor<BlockStatement, EsValue>> blockStatementProcessor)
//     {
//         _blockStatementProcessor = blockStatementProcessor;
//     }

//     public EsValue Process(FunctionExpression node, Scope scope)
//     {
//         var call = new Func<EsValue, EsValue[], EsValue>((thisContext, _arguments) => _blockStatementProcessor.Value.Process(node.Body, scope));

//         throw new NotImplementedException("Function expressions are not yet implemented.");

//         // return new FunctionValue(call, scope);
//     }
// }