using System.Collections.Generic;

namespace Core.LexicalAnalyzer
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }
        public int Character { get; set; }
        public int Line { get; set; }
        public List<TokenType> AllowFollows { get; set; }
    }
}
