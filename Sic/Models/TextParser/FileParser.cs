using Sic.Models.Music;

namespace Sic.Models.TextParser;
public static class FileParser
{
    private readonly static ListParser<NoteParser, Note> parser = new(new());

    public static IEnumerable<Note> ParseFile(string filePath)
    {
        using StreamReader inp = new(filePath);

        return parser.TryParse(inp);
    }
}