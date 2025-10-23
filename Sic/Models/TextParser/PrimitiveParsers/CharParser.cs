
namespace Sic.Models.TextParser.PrimitiveParsers;

class CharParser : IParser<char>
{
    private readonly char character;

    public CharParser(char character)
    {
        this.character = character;
    }

    public bool IsPrefix(char c)
    {
        return c == character;
    }

    public char TryParse(TextReader textReader)
    {
        if ((char)textReader.Read() == character)
        {
            return character;
        }
        throw new("Tried to parse character but got wrong character");
    }
}