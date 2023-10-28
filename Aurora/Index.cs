using Core.LexicalAnalyzer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Aurora
{
    public partial class Index : Form
    {
        public readonly ILexicalAnalyzer _compiler;

        public Index(ILexicalAnalyzer compiler)
        {
            _compiler = compiler;
            InitializeComponent();
        }

        private void tokenizeButton_Click(object sender, EventArgs e)
        {
            var tokens = _compiler.Tokenize(textInput.Text);
            var tokenList = new TokenListForm(tokens);
            tokenList.Show();
        }

        private void buttonCompile_Click(object sender, EventArgs e)
        {
            var tokens = _compiler.Tokenize(textInput.Text);

            if (tokens.HasErrors)
            {
                var messages = tokens.Errors.Select(x => $"Caracter '{x.Value}' inesperado en caracter {x.Character}");

                var concatenatedMessages = string.Join(Environment.NewLine, messages);

                textBoxProblems.Text = concatenatedMessages;
            }
        }
    }
}
