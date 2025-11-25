using Sic.Models.Music.Melodies;

namespace Sic.Models.TextParser;
public static class FileParser
{
    private readonly static MelodyParser parser = new();

    public static Melody ParseFile(string filePath)
    {
        using StreamReader inp = new(filePath);

        return parser.TryParse(inp);
    }
}