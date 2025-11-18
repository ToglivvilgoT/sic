using Sic.Models.TextParser.AggregatedParsers;
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser;

class StringParser(string str) : IParser<string>
{
    public bool IsPrefix(char c)
    {
        return str == "" || new CharParser(str[0]).IsPrefix(c);
    }

    public string TryParse(TextReader textReader)
    {
        foreach (char c in str)
        {
            new CharParser(c).TryParse(textReader);
        }
        return str;
    }
}