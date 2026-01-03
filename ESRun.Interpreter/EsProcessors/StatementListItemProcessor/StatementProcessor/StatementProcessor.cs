// using Esprima.Ast;
// using ESRun.Interpreter.EsProcessors.Abstract;
// using ESRun.Interpreter.EsScope;
// using ESRun.Interpreter.EsTypes.Abstract;
// using ESRun.Interpreter.LanguageTypes;

// namespace ESRun.Interpreter.EsProcessors;

// public class StatementProcessor : INodeProcessor<Statement, EsValue>
// {
//     private readonly Lazy<INodeProcessor<BlockStatement, EsValue>> _blockStatementProcessor;
//     private readonly Lazy<INodeProcessor<Declaration, EsValue>> _declarationProcessor;
//     private readonly Lazy<INodeProcessor<ExpressionStatement, EsValue>> _expressionStatementProcessor;

//     public StatementProcessor(Lazy<INodeProcessor<BlockStatement, EsValue>> blockStatementProcessor,
//         Lazy<INodeProcessor<Declaration, EsValue>> declarationProcessor,
//         Lazy<INodeProcessor<ExpressionStatement, EsValue>> expressionStatementProcessor)
//     {
//         _blockStatementProcessor = blockStatementProcessor;
//         _declarationProcessor = declarationProcessor;
//         _expressionStatementProcessor = expressionStatementProcessor;
//     }

//     public EsValue Process(Statement node, Scope scope)
//     {
//         switch (node)
//         {
//             case BlockStatement blockStatementNode:
//                 return _blockStatementProcessor.Value.Process(blockStatementNode, scope);
//             case Declaration declarationNode:
//                 return _declarationProcessor.Value.Process(declarationNode, scope);
//             case ExpressionStatement expressionStatementNode:
//                 return _expressionStatementProcessor.Value.Process(expressionStatementNode, scope);
//             default:
//                 throw new NotImplementedException($"Node type '{node.Type}' is not supported yet.");
//         }
//     }
// }