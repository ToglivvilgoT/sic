using Sic.Models.Music;
using Sic.Models.Music.Chords;
using Sic.Models.Music.Melodies;
using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser;

class ChordedMelodyParser : IParser<ChordedMelody>
{
    private static readonly SequentialParser<char, Chord, string, Melody, char> parser = new(
        new CharParser('['),
        new ChordParser(),
        new StringParser(", "),
        new MelodyParser(),
        new CharParser(']')
    );

    public bool IsPrefix(char c)
    {
        return parser.IsPrefix(c);
    }

    public ChordedMelody TryParse(TextReader textReader)
    {
        var (_, chord, _, melody, _) = parser.TryParse(textReader);
        return new ChordedMelody(chord, melody);
    }
}