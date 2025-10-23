using Sic.Models.Music;
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser;

class DurationParser : IParser<Duration>
{
    private static readonly NumberParser numberParser = new();

    public bool IsPrefix(char c)
    {
        return numberParser.IsPrefix(c);
    }

    public Duration TryParse(TextReader textReader)
    {
        int divisions = numberParser.TryParse(textReader);
        return new(1, divisions);
    }
}