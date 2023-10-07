using System.Collections.Generic;
using System.Linq;

namespace Core.LexicalAnalyzer
{
    public class TokenCollection : List<Token>
    {
        public int ErrorCount
        {
            get
            {
                return this.Where(e => e.Type == TokenType.Undefined).Count();
            }
        }

        public bool HasErrors
        {
            get
            {
                return ErrorCount > 0;
            }
        }

        public List<Error> Errors
        {
            get
            {
                return this.Where(e => e.Type == TokenType.Undefined).Select(e => new Error
                {
                    Value = e.Value,
                    Character = e.Character,
                    Line = e.Line
                }).ToList();
            }
        }
    }
}