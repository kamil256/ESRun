// using Esprima.Ast;
// using ESRun.Interpreter.EsProcessors.Abstract;
// using ESRun.Interpreter.EsScope;
// using ESRun.Interpreter.EsTypes.Abstract;
// using ESRun.Interpreter.EsTypes.Function;
// using ESRun.Interpreter.EsTypes.Undefined;
// using ESRun.Interpreter.LanguageTypes;

// namespace ESRun.Interpreter.EsProcessors;

// public class ExpressionProcessor : INodeProcessor<Expression, EsValue>
// {
//     private readonly Lazy<INodeProcessor<ArrowFunctionExpression, FunctionValue>> _arrowFunctionExpressionProcessor;
//     private readonly Lazy<INodeProcessor<CallExpression, EsValue>> _callExpressionProcessor;
//     private readonly Lazy<INodeProcessor<FunctionExpression, FunctionValue>> _functionExpressionProcessor;
//     private readonly Lazy<INodeProcessor<Literal, EsValue>> _literalProcessor;
//     private readonly Lazy<INodeProcessor<MemberExpression, EsValue>> _memberExpressionProcessor;
//     private readonly Lazy<INodeProcessor<ObjectExpression, EsValue>> _objectExpressionProcessor;

//     public ExpressionProcessor(Lazy<INodeProcessor<ArrowFunctionExpression, FunctionValue>> arrowFunctionExpressionProcessor,
//         Lazy<INodeProcessor<CallExpression, EsValue>> callExpressionProcessor,
//         Lazy<INodeProcessor<FunctionExpression, FunctionValue>> functionExpressionProcessor,
//         Lazy<INodeProcessor<Literal, EsValue>> literalProcessor,
//         Lazy<INodeProcessor<MemberExpression, EsValue>> memberExpressionProcessor,
//         Lazy<INodeProcessor<ObjectExpression, EsValue>> objectExpressionProcessor)
//     {
//         _arrowFunctionExpressionProcessor = arrowFunctionExpressionProcessor;
//         _callExpressionProcessor = callExpressionProcessor;
//         _functionExpressionProcessor = functionExpressionProcessor;
//         _literalProcessor = literalProcessor;
//         _memberExpressionProcessor = memberExpressionProcessor;
//         _objectExpressionProcessor = objectExpressionProcessor;
//     }

//     public EsValue Process(Expression node, Scope scope)
//     {
//         switch (node)
//         {
//             case ArrowFunctionExpression arrowFunctionExpressionNode:
//                 return _arrowFunctionExpressionProcessor.Value.Process(arrowFunctionExpressionNode, scope);
//             case CallExpression callExpressionNode:
//                 return _callExpressionProcessor.Value.Process(callExpressionNode, scope);
//             case FunctionExpression functionExpressionNode:
//                 return _functionExpressionProcessor.Value.Process(functionExpressionNode, scope);
//             case Identifier identifierNode:
//                 var identifier = identifierNode.Name;

//                 return scope.GetVariable(identifier, true)?.Value ?? UndefinedValue.Instance;
//             case Literal literalNode:
//                 return _literalProcessor.Value.Process(literalNode, scope);
//             case ObjectExpression objectExpressionNode:
//                 return _objectExpressionProcessor.Value.Process(objectExpressionNode, scope);
//             case StaticMemberExpression memberExpression:
//                 return _memberExpressionProcessor.Value.Process(memberExpression, scope);
//             default:
//                 throw new NotImplementedException($"Expression type '{node.Type}' is not supported yet.");
//         }
//     }
// }