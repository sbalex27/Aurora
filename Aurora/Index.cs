using Core.LexicalAnalyzer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Aurora
{
    public partial class Index : Form
    {
        public readonly IAnalyzer _compiler;

        public Index(IAnalyzer compiler)
        {
            _compiler = compiler;
            InitializeComponent();
        }

        private void tokenizeButton_Click(object sender, EventArgs e)
        {
            var tokens = _compiler.Tokenize(textInput.Text);
            new TokenListForm(tokens).Show();
        }

        private void buttonCompile_Click(object sender, EventArgs e)
        {
            textBoxProblems.Text = string.Empty;
            var tokens = _compiler.Tokenize(textInput.Text);

            if (tokens.HasErrors)
            {
                var messages = tokens.Errors.Select(x => $"Caracter '{x.Value}' inesperado en posición {x.Character}");
                textBoxProblems.Text = string.Join(Environment.NewLine, messages);
            } else
            {
                MessageBox.Show("Compilación exitosa");
            }
        }
    }
}
