
namespace Sic.Models.TextParser;

class OctaveParser : IParser<int>
{
    static bool IsValidOctave(char octave) {
        return '0' <= octave && octave <= '9';
    }
    public bool IsPrefix(char c)
    {
        return IsValidOctave(c);
    }

    public int TryParse(TextReader textReader)
    {
        int inp = textReader.Read();
        if (IsValidOctave((char)inp))
        {
            return inp - '0';
        }
        throw new("Tried to parse octave but got invalid octave number");
    }
}