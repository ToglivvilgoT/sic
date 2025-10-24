using Sic.Models.Music;
using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser;

class DurationParser : IParser<Duration>
{
    private static readonly char[] tripletChars = ['t', 'T'];
    private static readonly char notTripletChar = ' ';
    private static readonly SequentialParser<int, char> parser = new(
        new NumberParser(),
        new BranchingParser<char>(
            new CharParser(tripletChars[0]),
            new CharParser(tripletChars[1]),
            new EmptyParser<char>(notTripletChar)
        )
    );

    public bool IsPrefix(char c)
    {
        return parser.IsPrefix(c);
    }

    public Duration TryParse(TextReader textReader)
    {
        var (divisions, triplet) = parser.TryParse(textReader);
        if (tripletChars.Contains(triplet))
        {
            return new(2, divisions * 3);
        }
        return new(1, divisions);
    }
}