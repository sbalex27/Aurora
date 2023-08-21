using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core
{
    public enum TokenType
    {
        Keyword,
        Identifier,
    }

    public class Compiler
    {
        public List<Token> Tokenize(string input)
        {
            var patterns = new List<(string Pattern, TokenType type)>
            {
                (@"\binteger\b", TokenType.Keyword),
                (@"\bstring\b", TokenType.Keyword),
                (@"\b\w+\b", TokenType.Identifier),
            };

            List<Token> tokens = new List<Token>();

            foreach (var (pattern, type) in patterns)
            {
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    tokens.Add(new Token(type, match.Value));
                }
            }

            return tokens;
        }
    }

    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
