using Sic.Models.Music;
using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.ToneParsers;

namespace Sic.Models.TextParser;
public static class FileParser
{
    private readonly static ListParser<Note> parser = new(new NoteParser());

    public static IEnumerable<Note> ParseFile(string filePath)
    {
        using StreamReader inp = new(filePath);

        return parser.TryParse(inp);
    }
}