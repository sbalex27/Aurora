using System.Collections.Generic;

namespace Core.LexicalAnalyzer
{
    public interface ILexicalAnalyzer
    {
        List<Token> Tokenize(string input);
    }
}