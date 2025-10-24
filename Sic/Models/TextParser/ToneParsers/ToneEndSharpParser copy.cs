
using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser.ToneParsers;

class ToneEndSharpParser : IParser<int>
{
    private static readonly CharParser flatParser = new('#');
    private static readonly OctaveParser octaveParser = new();
    private static readonly SequentialParser<char, int> parser = new(flatParser, octaveParser);

    public bool IsPrefix(char c)
    {
        return parser.IsPrefix(c);
    }

    public int TryParse(TextReader textReader)
    {
        return parser.TryParse(textReader).Item2;
    }
}