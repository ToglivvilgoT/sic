using Sic.Models.Music.Intervals;
using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser;

class RelativeIntervalParser : IParser<RelativeInterval>
{
    private static readonly SequentialParser<char, int> parser = new(
        new BranchingParser<char>(
            new CharParser('-'),
            new EmptyParser<char>('+')
        ),
        new NumberParser()
    );

    public bool IsPrefix(char c)
    {
        return parser.IsPrefix(c);
    }

    public RelativeInterval TryParse(TextReader textReader)
    {
        var (sign, length) = parser.TryParse(textReader);
        if (length == 0)
        {
            throw new Exception("Tried to parse RelativeInterval and got length 0 (intervals start at 1)");
        }
        return new((length - 1) * (sign == '-' ? -1 : 1));
    }
}