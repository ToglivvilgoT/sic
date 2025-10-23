using Sic.Models.Music;
using Sic.Models.TextParser.PrimitiveParsers;
using Sic.Models.TextParser.ToneParsers;

namespace Sic.Models.TextParser;
public static class FileParser
{
    private readonly static ListParser<ToneParser, Tone> parser = new(new());

    public static IEnumerable<Tone> ParseFile(string filePath)
    {
        using StreamReader inp = new(filePath);

        return parser.TryParse(inp);
    }
}