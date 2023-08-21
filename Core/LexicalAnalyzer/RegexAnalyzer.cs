using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.LexicalAnalyzer
{
    public class RegexAnalyzer : ILexicalAnalyzer
    {
        public List<Token> Tokenize(string input)
        {
            var patterns = new List<(string Pattern, TokenType Type)>
            {
                (@"\bint\b", TokenType.Keyword),
                (@"\bstring\b", TokenType.Keyword),
                (@";", TokenType.Semicolon),
                (@"=", TokenType.Assignment),
                (@"\b\d+\b", TokenType.IntegerLiteral),
                (@"\b"".*?""\b", TokenType.StringLiteral),
                (@"\b\w+\b", TokenType.Identifier),
            };

            var joinedPatterns = string.Join("|", patterns.Select(e => $"({e.Pattern})"));
            var regex = new Regex(joinedPatterns, RegexOptions.Compiled);

            List<Token> tokens = new List<Token>();

            foreach (Match match in regex.Matches(input))
            {
                foreach (var (pattern, type) in patterns)
                {
                    if (Regex.IsMatch(match.Value, pattern))
                    {
                        Token token = new Token
                        {
                            Type = type,
                            Value = match.Value
                        };

                        tokens.Add(token);
                        break; // Detener el bucle una vez que se encuentra la coincidencia
                    }
                }
            }

            return tokens;
        }
    }
}
