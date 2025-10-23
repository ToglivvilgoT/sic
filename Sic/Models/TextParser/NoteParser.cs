using Sic.Models.Music;
using Sic.Models.TextParser.PrimitiveParsers;
using Sic.Models.TextParser.ToneParsers;

namespace Sic.Models.TextParser;

class NoteParser : IParser<Note>
{
    private static readonly ToneParser toneParser = new();
    private static readonly DurationParser durationParser = new();

    public bool IsPrefix(char c)
    {
        throw new NotImplementedException();
    }

    public Note TryParse(TextReader textReader)
    {
        throw new NotImplementedException();
    }
}