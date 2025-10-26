using Sic.Models.Music;
using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.PrimitiveParsers;
using Sic.Models.TextParser.ToneParsers;

namespace Sic.Models.TextParser;

public class NoteParser : IParser<Note>
{
    private static readonly SequentialParser<Tone, char, Duration> parser = new(
        new ToneParser(),
        new CharParser(':'),
        new DurationParser()
    );

    public bool IsPrefix(char c)
    {
        return parser.IsPrefix(c);
    }

    public Note TryParse(TextReader textReader)
    {
        var (tone, _, duration) = parser.TryParse(textReader);
        return new Note(tone, duration);
    }
}