using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.LexicalAnalyzer
{
    using TokenPatternList = List<(string Pattern, TokenType Type)>;

    public class SqlAnalyzer : IAnalyzer
    {
        private readonly TokenPatternList _patterns;
        private readonly Regex _compiled;

        public SqlAnalyzer()
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
                (@"\S+", TokenType.Undefined),
            };

            _compiled = new Regex(string.Join("|", _patterns.Select(e => $"({e.Pattern})")), RegexOptions.Compiled);
        }

        public TokenCollection Tokenize(string input)
        {
            var matches = _compiled.Matches(input).Cast<Match>();
            var follows = GetFollows();
            TokenCollection tokens = new TokenCollection();
            foreach (var match in matches)
            {
                foreach (var (pattern, type) in _patterns)
                {
                    if (Regex.IsMatch(match.Value, pattern))
                    {
                        //var allowFollows = follows.FirstOrDefault(x => x.Item1 == type).Item2;
                        var allowFollows = follows.Where(x => x.Item1 == type).SelectMany(x => x.Item2).ToList();
                        Token token = new Token
                        {
                            Type = type,
                            Value = match.Value,
                            Character = match.Index,
                            Line = 1,// TODO: Implement line counting
                            AllowFollows = allowFollows,
                        };

                        tokens.Add(token);
                        break;
                    }
                }
            }

            return tokens;
        }

        public List<(TokenType, TokenType[])> GetFollows()
        {
            return new List<(TokenType, TokenType[])>
            {
                (TokenType.Select, new[] {
                    TokenType.Asterisk,
                    TokenType.Identifier,
                }),
                (TokenType.From, new[]
                {
                    TokenType.Identifier,
                }),
                (TokenType.Where, new[]
                {
                    TokenType.Identifier,
                }),
                (TokenType.OrderBy, new[]
                {
                    TokenType.Identifier,
                }),
                (TokenType.Insert, new[]
                {
                    TokenType.Into,
                }),
                (TokenType.Into, new[]
                {
                    TokenType.Identifier,
                }),
                (TokenType.Values, new[]
                {
                    TokenType.Match,
                    TokenType.Number,
                }),
                (TokenType.Update, new[]
                {
                    TokenType.Identifier,
                }),
                (TokenType.Set, new[]
                {
                    TokenType.Identifier,
                }),
                (TokenType.Delete, new[]
                {
                    TokenType.From,
                }),
                (TokenType.Identifier, new[]
                {
                    TokenType.Comma,
                    TokenType.Where,
                    TokenType.Asc,
                    TokenType.Desc,
                    TokenType.Undefined,
                    TokenType.Equals,
                    TokenType.Set,
                }),
                (TokenType.Match, new[]
                {
                    TokenType.Comma,
                    TokenType.Where,
                    TokenType.Asc,
                    TokenType.Desc,
                    TokenType.Undefined,
                }),
                (TokenType.Number, new[]
                {
                    TokenType.Comma,
                    TokenType.Where,
                    TokenType.Asc,
                    TokenType.Desc,
                    TokenType.OrderBy,
                }),
                (TokenType.Comma, new[]
                {
                    TokenType.Identifier,
                    TokenType.Match,
                    TokenType.Number,
                }),
                (TokenType.Asterisk, new[]
                {
                    TokenType.From,
                }),
                (TokenType.Equals, new[]
                {
                    TokenType.Match,
                    TokenType.Number,
                }),
            };
        }
    }
}
