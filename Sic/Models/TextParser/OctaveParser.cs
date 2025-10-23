
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser;

class OctaveParser : IParser<int>
{
    private static readonly DigitParser digitParser = new();

    public bool IsPrefix(char c)
    {
        return digitParser.IsPrefix(c);
    }

    public int TryParse(TextReader textReader)
    {
        return (digitParser.TryParse(textReader) - 4) * 12;
    }
}