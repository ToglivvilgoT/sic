using Sic.Models.Music;
using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser.ToneParsers;

public class ToneParser : IParser<Pitch>
{
    private static readonly ToneLetterParser toneLetterParser = new();
    private static readonly ToneEndParser toneEndParser = new();
    private static readonly SequentialParser<char, int> parser = new(toneLetterParser, toneEndParser);

    private static readonly Dictionary<char, int> letterToPitch = new()
    {
        {'c',  0}, {'C',  0},
        {'d',  2}, {'D',  2},
        {'e',  4}, {'E',  4},
        {'f',  5}, {'F',  5},
        {'g',  7}, {'G',  7},
        {'a',  9}, {'A',  9},
        {'b', 11}, {'B', 11},
    };

    public bool IsPrefix(char c)
    {
        return parser.IsPrefix(c);
    }

    public Pitch TryParse(TextReader textReader)
    {
        var (letter, pitch) = parser.TryParse(textReader);
        return new(pitch + letterToPitch[letter]);
    }
}