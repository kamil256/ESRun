using Esprima.Ast;
using ESRun.Interpreter.EsProcessors;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsTypes.Abstract;
using ESRun.Interpreter.EsTypes.Function;
using ESRun.Interpreter.EsTypes.Object;
using Microsoft.Extensions.DependencyInjection;

namespace ESRun.Interpreter;

public static class ServiceRegistration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services
        .AddSingleton<INodeProcessor<ArrowFunctionExpression, FunctionValue>, ArrowFunctionExpressionProcessor>()
        .AddSingleton<INodeProcessor<BlockStatement, EsValue>, BlockStatementProcessor>()
        .AddSingleton<INodeProcessor<CallExpression, EsValue>, CallExpressionProcessor>()
        .AddSingleton<INodeProcessor<Declaration, EsValue>, DeclarationProcessor>()
        .AddSingleton<INodeProcessor<Expression, EsValue>, ExpressionProcessor>()
        .AddSingleton<INodeProcessor<ExpressionStatement, EsValue>, ExpressionStatementProcessor>()
        .AddSingleton<INodeProcessor<FunctionExpression, FunctionValue>, FunctionExpressionProcessor>()
        .AddSingleton<INodeProcessor<Literal, EsValue>, LiteralProcessor>()
        .AddSingleton<INodeProcessor<MemberExpression, EsValue>, MemberExpressionProcessor>()
        .AddSingleton<INodeProcessor<ObjectExpression, EsValue>, ObjectExpressionProcessor>()
        .AddSingleton<INodeProcessor<Property, KeyValuePair<string, SimplePropertyDescriptor>>, PropertyProcessor>()
        .AddSingleton<INodeProcessor<Script, EsValue>, ScriptProcessor>()
        .AddSingleton<INodeProcessor<Statement, EsValue>, StatementProcessor>()
        .AddSingleton<INodeProcessor<StaticMemberExpression, EsValue>, StaticMemberExpressionProcessor>()
        .AddSingleton<INodeProcessor<VariableDeclaration, EsValue>, VariableDeclarationProcessor>()
        .AddSingleton<INodeProcessor<VariableDeclarator, KeyValuePair<string, EsValue>>, VariableDeclaratorProcessor>()
        .AddSingleton(sp => new Lazy<INodeProcessor<ArrowFunctionExpression, FunctionValue>>(() => sp.GetRequiredService<INodeProcessor<ArrowFunctionExpression, FunctionValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<BlockStatement, EsValue>>(() => sp.GetRequiredService<INodeProcessor<BlockStatement, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<CallExpression, EsValue>>(() => sp.GetRequiredService<INodeProcessor<CallExpression, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<Declaration, EsValue>>(() => sp.GetRequiredService<INodeProcessor<Declaration, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<Expression, EsValue>>(() => sp.GetRequiredService<INodeProcessor<Expression, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<ExpressionStatement, EsValue>>(() => sp.GetRequiredService<INodeProcessor<ExpressionStatement, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<FunctionExpression, FunctionValue>>(() => sp.GetRequiredService<INodeProcessor<FunctionExpression, FunctionValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<Literal, EsValue>>(() => sp.GetRequiredService<INodeProcessor<Literal, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<MemberExpression, EsValue>>(() => sp.GetRequiredService<INodeProcessor<MemberExpression, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<ObjectExpression, EsValue>>(() => sp.GetRequiredService<INodeProcessor<ObjectExpression, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<Property, KeyValuePair<string, SimplePropertyDescriptor>>>(() => sp.GetRequiredService<INodeProcessor<Property, KeyValuePair<string, SimplePropertyDescriptor>>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<Script, EsValue>>(() => sp.GetRequiredService<INodeProcessor<Script, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<Statement, EsValue>>(() => sp.GetRequiredService<INodeProcessor<Statement, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<StaticMemberExpression, EsValue>>(() => sp.GetRequiredService<INodeProcessor<StaticMemberExpression, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<VariableDeclaration, EsValue>>(() => sp.GetRequiredService<INodeProcessor<VariableDeclaration, EsValue>>()))
        .AddSingleton(sp => new Lazy<INodeProcessor<VariableDeclarator, KeyValuePair<string, EsValue>>>(() => sp.GetRequiredService<INodeProcessor<VariableDeclarator, KeyValuePair<string, EsValue>>>()));
    }
}