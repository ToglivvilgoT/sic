
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser.AggregatedParsers;

public class SequentialParser<P1, T1, P2, T2> : IParser<(T1, T2)> where P1 : IParser<T1> where P2 : IParser<T2>
{
    private readonly P1 parser1;
    private readonly P2 parser2;

    public SequentialParser(P1 parser1, P2 parser2)
    {
        this.parser1 = parser1;
        this.parser2 = parser2;
    }

    public bool IsPrefix(char c)
    {
        return parser1.IsPrefix(c);
    }

    public (T1, T2) TryParse(TextReader textReader)
    {
        return (parser1.TryParse(textReader), parser2.TryParse(textReader));
    }
}

public class SequentialParser<P1, T1, P2, T2, P3, T3> : IParser<(T1, T2, T3)> where P1 : IParser<T1> where P2 : IParser<T2> where P3 : IParser<T3>
{
    private readonly P1 parser1;
    private readonly P2 parser2;
    private readonly P3 parser3;

    public SequentialParser(P1 parser1, P2 parser2, P3 parser3)
    {
        this.parser1 = parser1;
        this.parser2 = parser2;
        this.parser3 = parser3;
    }

    public bool IsPrefix(char c)
    {
        return parser1.IsPrefix(c);
    }

    public (T1, T2, T3) TryParse(TextReader textReader)
    {
        return (parser1.TryParse(textReader), parser2.TryParse(textReader), parser3.TryParse(textReader));
    }
}