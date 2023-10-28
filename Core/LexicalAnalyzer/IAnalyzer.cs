namespace Core.LexicalAnalyzer
{
    public interface IAnalyzer
    {
        TokenCollection Tokenize(string input);
    }
}