namespace Core.LexicalAnalyzer
{
    public class Error
    {
        public string Value { get; set; }
        public int Character { get; set; }
        public int Line { get; set; }
    }
}