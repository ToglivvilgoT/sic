
namespace Sic.Models.TextParser.PrimitiveParsers;

class BlankParser : IParser<char>
{
    private static readonly char[] blanks = [' ', '\t', '\n', '\r'];

    public bool IsPrefix(char c)
    {
        return blanks.Contains(c);
    }

    public char TryParse(TextReader textReader)
    {
        char next = (char)textReader.Read();
        if (!blanks.Contains(next))
        {
            throw new("Tried to parse blank but got no blank");
        }
        return next;
    }
}