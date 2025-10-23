namespace Sic.Models.TextParser.PrimitiveParsers;

public interface IParser<T>
{
    public bool IsPrefix(char c);
    public T TryParse(TextReader textReader);
}