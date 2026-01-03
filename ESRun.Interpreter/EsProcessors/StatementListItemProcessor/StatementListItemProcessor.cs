// using Esprima.Ast;
// using ESRun.Interpreter.EsProcessors.Abstract;
// using ESRun.Interpreter.EsScope;
// using ESRun.Interpreter.EsTypes.Abstract;
// using ESRun.Interpreter.LanguageTypes;

// namespace ESRun.Interpreter.EsProcessors;

// public class StatementListItemProcessor : INodeProcessor<StatementListItem, EsValue>
// {
//     private readonly Lazy<INodeProcessor<Statement, EsValue>> _statementProcessor;

//     public StatementListItemProcessor(Lazy<INodeProcessor<Statement, EsValue>> statementProcessor)
//     {
//         _statementProcessor = statementProcessor;
//     }

//     public EsValue Process(StatementListItem node, Scope scope)
//     {
//         switch (node)
//         {
//             case Statement statementNode:
//                 return _statementProcessor.Value.Process(statementNode, scope);
//             default:
//                 throw new NotImplementedException($"Node type '{node.Type}' is not supported yet.");
//         }
//     }
// }