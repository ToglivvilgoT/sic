namespace Sic.Models.TextParser;

interface IParser<T>
{
    public bool IsPrefix(char c);
    public T TryParse(TextReader textReader);
}