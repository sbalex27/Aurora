using Core.LexicalAnalyzer;
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
    public partial class TokenListForm : Form
    {
        public readonly List<Token> _tokens;

        public TokenListForm(List<Token> tokens)
        {
            _tokens = tokens;
            InitializeComponent();
            RenderTokens();
        }

        private void RenderTokens()
        {
            foreach (var token in _tokens)
            {
                var item = new ListViewItem(token.Type.ToString());
                item.SubItems.Add(token.Value);
                tokenListView.Items.Add(item);
            }
        }
    }
}
