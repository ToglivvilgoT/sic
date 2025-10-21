
namespace Sic.Models.TextParser;

class MultipleParser<P, T> : IParser<IEnumerable<T>> where P : IParser<T>
{
    private readonly P parser;

    public MultipleParser(P parser)
    {
        this.parser = parser;
    }

    public bool IsPrefix(char c)
    {
        return parser.IsPrefix(c);
    }

    public IEnumerable<T> TryParse(TextReader textReader)
    {
        List<T> values = [];
        while(parser.IsPrefix((char)textReader.Peek()))
        {
            values.Add(parser.TryParse(textReader));
        }
        return values;
    }
}