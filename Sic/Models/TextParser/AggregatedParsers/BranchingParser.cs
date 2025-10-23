
using Sic.Models.TextParser.PrimitiveParsers;

namespace Sic.Models.TextParser.AggregatedParsers;

class BranchingParser<T> : IParser<T>
{
    private readonly IParser<T>[] parsers;

    public BranchingParser(params IParser<T>[] parsers)
    {
        this.parsers = parsers;
    }

    public bool IsPrefix(char c)
    {
        return parsers.Any((parser) => parser.IsPrefix(c));
    }

    public T TryParse(TextReader textReader)
    {
        char first = (char)textReader.Peek();
        var candidates = parsers.Where((parser) => parser.IsPrefix(first));
        if (candidates.Count() != 1)
        {
            throw new("Tried to do branching parse but multiple sub-parsers had valid prefix");
        }
        return candidates.First().TryParse(textReader);
    }
}