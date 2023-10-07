using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.LexicalAnalyzer
{
    using TokenPatternList = List<(string Pattern, TokenType Type)>;

    public class SqlLexicalAnalyzer : ILexicalAnalyzer
    {
        private readonly TokenPatternList _patterns;
        private readonly Regex _compiled;

        public SqlLexicalAnalyzer()
        {
            _patterns = new TokenPatternList
            {
                (@"SELECT", TokenType.Select),
                (@"FROM", TokenType.From),
                (@"WHERE", TokenType.Where),
                (@"ORDER BY", TokenType.OrderBy),
                (@"INSERT", TokenType.Insert),
                (@"INTO", TokenType.Into),
                (@"VALUES", TokenType.Values),
                (@"UPDATE", TokenType.Update),
                (@"SET", TokenType.Set),
                (@"DELETE", TokenType.Delete),
                (@"=", TokenType.Equals),
                (@"LIKE", TokenType.Like),
                (@"NOT", TokenType.Not),
                (@"DESC", TokenType.Desc),
                (@"ASC", TokenType.Asc),
                (@",", TokenType.Comma),
                (@"\*", TokenType.Asterisk),
                (@"'.*'", TokenType.Match),
                (@"\d+", TokenType.Number),
                (@"\b[A-Za-z_]\w*\b", TokenType.Identifier),
            };

            _compiled = new Regex(string.Join("|", _patterns.Select(e => $"({e.Pattern})")), RegexOptions.Compiled);
        }

        public List<Token> Tokenize(string input)
        {
            var matches = _compiled.Matches(input).Cast<Match>();

            List<Token> tokens = new List<Token>();
            foreach (var match in matches)
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
