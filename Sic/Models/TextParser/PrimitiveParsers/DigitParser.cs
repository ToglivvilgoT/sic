
namespace Sic.Models.TextParser.PrimitiveParsers;

class DigitParser : IParser<int>
{
    static bool IsValidDigit(char digit) {
        return '0' <= digit && digit <= '9';
    }
    public bool IsPrefix(char c)
    {
        return IsValidDigit(c);
    }

    public int TryParse(TextReader textReader)
    {
        int inp = textReader.Read();
        if (IsValidDigit((char)inp))
        {
            return inp - '0';
        }
        throw new("Tried to parse digit but got invalid character outside '0'-'9'");
    }
}