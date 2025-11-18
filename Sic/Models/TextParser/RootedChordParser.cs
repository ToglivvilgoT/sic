using Microsoft.VisualBasic;
using Sic.Models.Music.Chords;
using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser;

class RootedChordParser : IParser<RootedChord>
{
    private static readonly SequentialParser<char, Chord> parser = new(
        new ToneLetterParser(),
        new ChordParser()
    );

    public bool IsPrefix(char c)
    {
        return parser.IsPrefix(c);
    }

    public RootedChord TryParse(TextReader textReader)
    {
        var (c, chord) = parser.TryParse(textReader);
        return new RootedChord(chord, new Music.Tone(c.ToString().ToLower()[0] - 'c'));
    }
}