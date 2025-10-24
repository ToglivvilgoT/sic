
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser.AggregatedParsers;

public class SequentialParser<T1, T2>(IParser<T1> parser1, IParser<T2> parser2) : IParser<(T1, T2)>
{
    private readonly IParser<T1> parser1 = parser1;
    private readonly IParser<T2> parser2 = parser2;

    public bool IsPrefix(char c)
    {
        return parser1.IsPrefix(c);
    }

    public (T1, T2) TryParse(TextReader textReader)
    {
        return (parser1.TryParse(textReader), parser2.TryParse(textReader));
    }
}

public class SequentialParser<T1, T2, T3>(IParser<T1> parser1, IParser<T2> parser2, IParser<T3> parser3) : IParser<(T1, T2, T3)>
{
    private readonly IParser<T1> parser1 = parser1;
    private readonly IParser<T2> parser2 = parser2;
    private readonly IParser<T3> parser3 = parser3;

    public bool IsPrefix(char c)
    {
        return parser1.IsPrefix(c);
    }

    public (T1, T2, T3) TryParse(TextReader textReader)
    {
        return (parser1.TryParse(textReader), parser2.TryParse(textReader), parser3.TryParse(textReader));
    }
}