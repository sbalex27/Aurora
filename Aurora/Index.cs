using Core;
using System;
using System.Windows.Forms;

namespace Aurora
{
    public partial class Index : Form
    {
        public readonly Compiler _compiler;

        public Index(Compiler compiler)
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
    }
}
