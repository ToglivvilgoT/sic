
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser.AggregatedParsers;

class MultipleParser<T> : IParser<IEnumerable<T>>
{
    private readonly IParser<T> parser;

    public MultipleParser(IParser<T> parser)
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