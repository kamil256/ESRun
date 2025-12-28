namespace ESRun.GUI;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        splitContainer1 = new SplitContainer();
        button1 = new Button();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        SuspendLayout();
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(0, 0);
        splitContainer1.Name = "splitContainer1";
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(button1);
        splitContainer1.Panel1.Controls.Add(textBox1);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(textBox2);
        splitContainer1.Size = new Size(782, 450);
        splitContainer1.SplitterDistance = 391;
        splitContainer1.TabIndex = 0;
        // 
        // button1
        // 
        button1.FlatStyle = FlatStyle.Flat;
        button1.Location = new Point(334, 7);
        button1.Name = "button1";
        button1.Size = new Size(50, 29);
        button1.TabIndex = 1;
        button1.Text = "Run";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBox1.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBox1.Location = new Point(3, 3);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(385, 444);
        textBox1.TabIndex = 0;
        // 
        // textBox2
        // 
        textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        textBox2.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBox2.Location = new Point(3, 3);
        textBox2.Multiline = true;
        textBox2.Name = "textBox2";
        textBox2.ReadOnly = true;
        textBox2.ScrollBars = ScrollBars.Both;
        textBox2.Size = new Size(381, 444);
        textBox2.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(782, 450);
        Controls.Add(splitContainer1);
        Name = "Form1";
        Text = "ESRun";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel1.PerformLayout();
        splitContainer1.Panel2.ResumeLayout(false);
        splitContainer1.Panel2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitContainer1;
    private TextBox textBox1;
    private TextBox textBox2;
    private Button button1;
}
