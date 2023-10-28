using System.Collections.Generic;
using System.Linq;

namespace Core.LexicalAnalyzer
{
    public class TokenCollection : List<Token>
    {
        public int UndefinedCount
        {
            get
            {
                return this.Where(e => e.Type == TokenType.Undefined).Count();
            }
        }

        public bool HasUndefined
        {
            get
            {
                return UndefinedCount > 0;
            }
        }

        public List<Error> Errors
        {
            get
            {
                var result = new List<Error>();

                var undefineds = this.Where(e => e.Type == TokenType.Undefined).Select(e => new Error
                {
                    Value = e.Value,
                    Character = e.Character,
                    Line = e.Line
                }).ToList();

                result.AddRange(undefineds);

                var unespectedTokens = UnespectedTokens.Select(e => new Error
                {
                    Value = e.Value,
                    Character = e.Character,
                    Line = e.Line
                }).ToList();

                result.AddRange(unespectedTokens);

                return result;
            }
        }

        public bool HasErrors
        {
            get
            {
                return Errors.Count > 0;
            }
        }

        public List<Token> UnespectedTokens
        {
            get
            {
                var result = new List<Token>();

                foreach (var token in this)
                {
                    var index = IndexOf(token);
                    var nextToken = this.ElementAtOrDefault(index + 1);

                    if (nextToken != null)
                    {
                        var atLeastOneFollow = token.AllowFollows.Count > 0;
                        if (!token.AllowFollows.Contains(nextToken.Type) && atLeastOneFollow)
                        {
                            result.Add(nextToken);
                        }
                    }
                }

                return result;
            }
        }

        public bool HasUnespectedTokens
        {
            get
            {
                return UnespectedTokens.Count > 0;
            }
        }
    }
}