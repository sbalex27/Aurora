namespace Core.LexicalAnalyzer
{
    public interface ILexicalAnalyzer
    {
        TokenCollection Tokenize(string input);
    }
}