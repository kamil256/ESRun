using Esprima;
using Esprima.Ast;
using ESRun.Interpreter.EsProcessors.Abstract;
using ESRun.Interpreter.EsScope;
using ESRun.Interpreter.LanguageTypes;

namespace ESRun.GUI;

public partial class Form1 : Form
{
    private readonly Lazy<INodeProcessor<Script, EsValue>> _scriptProcessor;

    public Form1(Lazy<INodeProcessor<Script, EsValue>> scriptProcessor)
    {
        InitializeComponent();
        _scriptProcessor = scriptProcessor;
    }

    public void LogInfo(string message)
    {
        if (textBox2.Text.Length > 0)
        {
            textBox2.Text += "\r\n\r\n";
        }

        textBox2.Text += message;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var parser = new JavaScriptParser();
        var script = parser.ParseScript(textBox1.Text);

        _scriptProcessor.Value.Process(script, new Scope(GlobalScope.Instance));
    }
}
