using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Core.LexicalAnalyzer
{
    using TokenPatternList = List<(string Pattern, TokenType Type)>;
    
    public class RegexAnalyzer : ILexicalAnalyzer
    {
        private readonly TokenPatternList _patterns;
        private readonly Regex _compiledPatterns;

        public RegexAnalyzer()
        {
            _patterns = new TokenPatternList
            {
                (@"\bint\b", TokenType.Keyword),
                (@"\bstring\b", TokenType.Keyword),
                (@";", TokenType.Semicolon),
                (@"=", TokenType.Assignment),
                (@"\b\d+\b", TokenType.IntegerLiteral),
                (@"\b"".*?""\b", TokenType.StringLiteral),
                (@"\b\w+\b", TokenType.Identifier),
            };

            var joinedPatterns = string.Join("|", _patterns.Select(e => $"({e.Pattern})"));

            _compiledPatterns = new Regex(joinedPatterns, RegexOptions.Compiled);
        }

        public List<Token> Tokenize(string input)
        {
            List<Token> tokens = new List<Token>();

            foreach (Match match in _compiledPatterns.Matches(input))
            {
                foreach (var (pattern, type) in _patterns)
                {
                    if (Regex.IsMatch(match.Value, pattern))
                    {
                        Token token = new Token
                        {
                            Type = type,
                            Value = match.Value
                        };

                        tokens.Add(token);
                        break;
                    }
                }
            }

            return tokens;
        }
    }
}
