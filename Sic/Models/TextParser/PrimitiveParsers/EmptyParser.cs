
namespace Sic.Models.TextParser.PrimitiveParsers;

class EmptyParser<T>(T parseValue) : IParser<T>
{
    private readonly T parseValue = parseValue;

    public bool IsPrefix(char c)
    {
        return true;
    }

    public T TryParse(TextReader textReader)
    {
        return parseValue;
    }
}