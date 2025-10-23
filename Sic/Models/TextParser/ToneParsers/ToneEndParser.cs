
using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser.ToneParsers;

class ToneEndParser : IParser<int>
{
    private static readonly OctaveParser normalParser = new();
    private static readonly ToneEndFlatParser flatParser = new();
    private static readonly ToneEndSharpParser sharpParser = new();
    private static readonly BranchingParser<int> parser = new(normalParser, flatParser, sharpParser);

    public bool IsPrefix(char c)
    {
        return parser.IsPrefix(c);
    }

    public int TryParse(TextReader textReader)
    {
        return parser.TryParse(textReader);
    }
}