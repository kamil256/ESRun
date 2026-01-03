// using Esprima.Ast;
// using ESRun.Interpreter.EsProcessors.Abstract;
// using ESRun.Interpreter.EsScope;
// using ESRun.Interpreter.EsTypes.Abstract;
// using ESRun.Interpreter.EsTypes.Undefined;
// using ESRun.Interpreter.LanguageTypes;

// namespace ESRun.Interpreter.EsProcessors;

// public class VariableDeclaratorProcessor : INodeProcessor<VariableDeclarator, KeyValuePair<string, EsValue>>
// {
//     private readonly Lazy<INodeProcessor<Expression, EsValue>> _expressionProcessor;

//     public VariableDeclaratorProcessor(Lazy<INodeProcessor<Expression, EsValue>> expressionProcessor)
//     {
//         _expressionProcessor = expressionProcessor;
//     }

//     public KeyValuePair<string, EsValue> Process(VariableDeclarator node, Scope scope)
//     {
//         if (node.Id is not Identifier identifierNode)
//         {
//             throw new NotImplementedException("Only Identifier is supported in VariableDeclarator.Id");
//         }

//         var identifier = identifierNode.Name;

//         var value = node.Init != null
//             ? _expressionProcessor.Value.Process(node.Init, scope)
//             : UndefinedValue.Instance;

//         return new KeyValuePair<string, EsValue>(identifier, value);
//     }
// }