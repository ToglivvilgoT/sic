
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser.AggregatedParsers;

class ListParser<T>(IParser<T> parser) : IParser<IEnumerable<T>>
{
    private readonly IParser<T> parser = parser;
    private static readonly MultipleParser<char> blankParser = new(new BlankParser());

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