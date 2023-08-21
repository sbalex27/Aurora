using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aurora
{
    public partial class TokenList : Form
    {
        public readonly List<Token> _tokens;

        public TokenList(List<Token> tokens)
        {
            _tokens = tokens;
            InitializeComponent();
            RenderTokens();
        }

        private void RenderTokens()
        {
            foreach (var token in _tokens)
            {
                tokenListView.Items.Add($"{token.Type} - {token.Value}");
            }
        }
    }
}
