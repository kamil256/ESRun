// using Esprima.Ast;
// using ESRun.Interpreter.EsProcessors.Abstract;
// using ESRun.Interpreter.EsScope;
// using ESRun.Interpreter.LanguageTypes;
// using ESRun.Interpreter.SpecificationTypes;

// namespace ESRun.Interpreter.EsProcessors;

// public class ObjectExpressionProcessor : INodeProcessor<ObjectExpression, EsValue>
// {
//     protected readonly Lazy<INodeProcessor<Property, KeyValuePair<EsString, PropertyDescriptor>>> _propertyProcessor;

//     public ObjectExpressionProcessor(
//         Lazy<INodeProcessor<Property, KeyValuePair<EsString, PropertyDescriptor>>> propertyProcessor)
//     {
//         _propertyProcessor = propertyProcessor;
//     }

//     public EsValue Process(ObjectExpression node, Scope scope)
//     {
//         throw new NotImplementedException("Object expressions are not yet implemented.");
//         // var objectValue = new EsObject();

//         // foreach (var property in node.Properties)
//         // {
//         //     if (property is not Property propertyNode)
//         //     {
//         //         throw new NotImplementedException("Only standard properties are supported in object expressions.");
//         //     }

//         //     var (identifier, propertyDescriptor) = _propertyProcessor.Value.Process(propertyNode, scope);

//         //     objectValue.DefineOwnProperty(identifier, propertyDescriptor);
//         // }

//         // return objectValue;
//     }
// }