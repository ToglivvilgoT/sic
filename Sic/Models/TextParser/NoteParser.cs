using Sic.Models.Music;

namespace Sic.Models.TextParser;

public class NoteParser : IParser<Note>
{
    private static readonly NoteLetterParser noteLetterParser = new();
    private static readonly OctaveParser octaveParser = new();

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
        return new NoteLetterParser().IsPrefix(c);
    }

    public Note TryParse(TextReader stream)
    {
        char letter = new NoteLetterParser().TryParse(stream);
        int next = stream.Peek();
        int flatSharp = 0;
        if (next == '#' || next == 'b')
        {
            flatSharp = stream.Read() == '#' ? 1 : 0;
        }
        int octave = new OctaveParser().TryParse(stream);

        return new(letterToPitch[letter] + flatSharp + (octave - 4) * 12);
    }
}