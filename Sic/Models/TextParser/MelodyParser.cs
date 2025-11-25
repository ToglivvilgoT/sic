using Sic.Models.Music;
using Sic.Models.Music.Intervals;
using Sic.Models.Music.Melodies;
using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser;

class MelodyParser : IParser<Melody>
{
    private static readonly ListParser<(RelativeInterval, char, Duration)> parser = new(
        new SequentialParser<RelativeInterval, char, Duration>(
            new RelativeIntervalParser(),
            new CharParser(':'),
            new DurationParser()
        )
    );

    public bool IsPrefix(char c)
    {
        return parser.IsPrefix(c);
    }

    public Melody TryParse(TextReader textReader)
    {
        var stuffs = parser.TryParse(textReader);
        return new(
            stuffs.Select((tup) => tup.Item1),
            new(stuffs.Select((tup) => tup.Item3))
        );
    }
}