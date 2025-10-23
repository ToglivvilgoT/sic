
using Sic.Models.TextParser.AggregatedParsers;

namespace Sic.Models.TextParser.PrimitiveParsers;

class NumberParser : IParser<int>
{
    private static readonly MultipleParser<DigitParser, int> digitsParser = new(new());

    public bool IsPrefix(char c)
    {
        return digitsParser.IsPrefix(c);
    }

    public int TryParse(TextReader textReader)
    {
        IEnumerable<int> digits = digitsParser.TryParse(textReader);
        return digits.Aggregate(0, (a, b) => 10 * a + b);
    }
}