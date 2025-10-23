
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser;

class ToneLetterParser : IParser<char>
{
    private static bool IsValidLetter(char letter)
    {
        return 'a' <= letter && letter <= 'g' || 'A' <= letter && letter <= 'G';
    }

    public bool IsPrefix(char c)
    {
        return IsValidLetter(c);
    }

    public char TryParse(TextReader textReader)
    {
        char inp = (char)textReader.Read();
        if (IsValidLetter(inp))
        {
            return inp;
        }
        throw new("Tried to parse tone letter but got invalid letter");
    }
}
