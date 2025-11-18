using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser;

class ChordParser : IParser<Chord>
{
    private static readonly BranchingParser<string> parser = new([
        new StringParser("m"),
        new StringParser("M"),
        new StringParser("aug"),
        new StringParser("dim"),
    ]);
    public bool IsPrefix(char c)
    {
        return parser.IsPrefix(c);
    }

    public Chord TryParse(TextReader textReader)
    {
        return new Chord(parser.TryParse(textReader));
    }
}