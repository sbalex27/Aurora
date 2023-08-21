using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.LexicalAnalyzer
{
    public class LexicalAnalyzer : ILexicalAnalyzer
    {
        public List<Token> Tokenize(string input)
        {
            var patterns = new List<(string Pattern, TokenType Type)>
            {
                (@"\binteger\b", TokenType.Keyword),
                (@"\bstring\b", TokenType.Keyword),
                (@"\b\w+\b", TokenType.Identifier),
                (@"\b\d+\b", TokenType.IntegerLiteral),
                (@"\b"".*""\b", TokenType.StringLiteral),
                (@";", TokenType.Semicolon),
            };

            var joindedPatterns = string.Join("|", patterns.Select(e => $"\\b{e.Pattern}\\b"));
            var regex = new Regex(joindedPatterns, RegexOptions.Compiled);

            List<Token> tokens = new List<Token>();

            foreach (Match match in regex.Matches(input))
            {
                TokenType tokenType = patterns.FirstOrDefault(p => Regex.IsMatch(match.Value, $@"\b{p.Pattern}\b")).Type;

                Token token = new Token
                {
                    Type = tokenType,
                    Value = match.Value
                };

                tokens.Add(token);
            }

            return tokens;
        }
    }
}
