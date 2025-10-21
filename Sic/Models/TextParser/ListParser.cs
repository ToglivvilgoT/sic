
namespace Sic.Models.TextParser;

class ListParser<P, T> : IParser<IEnumerable<T>> where P : IParser<T>, new()
{
    private readonly P parser;
    private static readonly IParser<IEnumerable<char>> blankParser = new MultipleParser<BlankParser, char>(new BlankParser());

    public ListParser(P parser) {
        this.parser = parser;
    }

    public bool IsPrefix(char c)
    {
        return c == '[';
    }

    public IEnumerable<T> TryParse(TextReader textReader)
    {
        if (textReader.Read() != '[')
        {
            throw new("Tried to parse list but got no starting parenthesis '['");
        }

        if (blankParser.IsPrefix((char)textReader.Peek()))
        {
            blankParser.TryParse(textReader);
        }

        if (textReader.Peek() == ']')
        {
            textReader.Read();
            return [];
        }

        List<T> values = [];

        while (true)
        {
            T value = parser.TryParse(textReader);
            values.Add(value);
            int next = textReader.Read();
            if (next == ']')
            {
                break;
            }
            else if (next != ',')
            {
                throw new("Tried to parse list but got no end parenthesis ']' or delimiter ','");
            }

            if (blankParser.IsPrefix((char)textReader.Peek()))
            {
                blankParser.TryParse(textReader);
            }
        }
        return values;
    }
}